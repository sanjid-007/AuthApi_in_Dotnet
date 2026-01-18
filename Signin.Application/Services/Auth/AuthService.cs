using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Signin.Application.DTOs.AuthDTOs;
using Signin.Application.Interfaces.Auth;
using Signin.Domain.Entities;

namespace Signin.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        public readonly IUserRepository _userRepository;
        public readonly IPasswordHasher _passwordHasher;
        public readonly IJwtTokenService _jwtTokenService;
        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest dto)
        {
            var principal = _jwtTokenService.GetPrincipalFromExpiredToken(dto.Token);
            var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var role = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            var user = await _userRepository.FindUserByUsername(username);
            if (user == null || user.RefreshToken != dto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new Exception("Invalid refresh token");
            }
            var newJwtToken =  _jwtTokenService.GenerateJwtToken(user);
            var newRefreshToken =  _jwtTokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateUser(user);
            return new RefreshTokenResponse
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task<SigninResponse> SigninAsync(SigninRequest dto)
        {
            var user = await _userRepository.FindUserByUsername(dto.Username);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            if (!_passwordHasher.Verify(dto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid password");
            }
           var token =  _jwtTokenService.GenerateJwtToken(user);

            var refreshToken = _jwtTokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateUser(user);
            return new SigninResponse
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token,
                RefreshToken = refreshToken

            };

        }

        public async Task<LogoutResponse> SignoutAsync(string username)
        {
            var user = await _userRepository.FindUserByUsername(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = DateTime.MinValue; // Set to a default value instead of null
            await _userRepository.UpdateUser(user);
            return new LogoutResponse
            {
                Message = "User signed out successfully"
            };
        }

        public async Task<SignupResponse> SignupAsync(SignupRequest dto)
        {
            if((await _userRepository.FindUserByUsername(dto.Username)) != null)
            {
                throw new Exception("User already exists");
            }
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = _passwordHasher.Hash(dto.Password),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CreatedAt = DateTime.UtcNow
            };
            await _userRepository.CreateUser(user);

            return new SignupResponse
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
            };


        }
        public async Task<UpdateProfileResponse> UpdateProfileAsync(UpdateProfileRequest dto, string username)
        {
            var user =await _userRepository.FindUserByUsername(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.FirstName = dto.FirstName ?? user.FirstName;
            user.LastName = dto.LastName ?? user.LastName;
            await _userRepository.UpdateUser(user);
            return new UpdateProfileResponse
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }
    }
}
