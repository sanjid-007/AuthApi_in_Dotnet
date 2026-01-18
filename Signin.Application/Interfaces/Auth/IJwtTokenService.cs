using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Signin.Domain.Entities.Auth;

namespace Signin.Application.Interfaces.Auth
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
