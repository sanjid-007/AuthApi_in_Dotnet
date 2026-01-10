using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin.Application.DTOs
{
    public class RefreshTokenResponse
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; }
    }
}
