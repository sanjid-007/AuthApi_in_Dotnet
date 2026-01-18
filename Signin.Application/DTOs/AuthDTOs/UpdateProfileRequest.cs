using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin.Application.DTOs.AuthDTOs
{
    public class UpdateProfileRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
