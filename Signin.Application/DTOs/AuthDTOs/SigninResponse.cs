using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin.Application.DTOs.AuthDTOs
{
    public class SigninResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }

    }
}
