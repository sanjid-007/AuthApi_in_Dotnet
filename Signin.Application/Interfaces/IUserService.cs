
using Signin.Application.DTOs;

namespace Signin.Application.Interfaces
{
    public interface IUserService
    {
       Task<SignupResponse> CreateUserAsync(SignupRequest dto);
       Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest dto);
       Task<bool> DeleteUserAsync(string userId);




    }
}
