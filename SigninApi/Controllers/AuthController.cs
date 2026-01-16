using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Signin.Application.DTOs;
using Signin.Application.Interfaces;

namespace Signin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest dto)
        {
           var result = await _authService.SignupAsync(dto);
            return Ok(result);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] SigninRequest dto)
        {
            var result = await _authService.SigninAsync(dto);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest dto)
        {
            var result = await _authService.RefreshTokenAsync(dto);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest dto)
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            var result = await _authService.UpdateProfileAsync(dto,username);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("signout")]
        public async Task<IActionResult> Signout()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            var result = await _authService.SignoutAsync(username);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("me")]
        public async Task<IActionResult> Me()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            return Ok(new
            {
                Id = id,
                Username = username,
                Email = email,
                Role = role
            });
        }

    }
}
