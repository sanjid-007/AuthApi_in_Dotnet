using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Signin.Application.DTOs;

namespace Signin.Application.Interfaces
{
    public interface IAuthService
    {
        Task<SignupResponse> SignupAsync(SignupRequest dto);
        Task<SigninResponse> SigninAsync(SigninRequest dto);

        Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest dto);

        Task<UpdateProfileResponse> UpdateProfileAsync(UpdateProfileRequest dto, string username);
        Task<LogoutResponse> SignoutAsync(string userId);
    }
}
