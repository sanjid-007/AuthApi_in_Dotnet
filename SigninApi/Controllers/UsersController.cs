using Microsoft.AspNetCore.Mvc;
using Signin.Application.Interfaces;

namespace Signin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;
        public readonly IUserRepository _userRepository;

        public UsersController(IUserService userService, IUserRepository userRepository) {
            _userService = userService;
            _userRepository = userRepository;
        }
        

    }
}
