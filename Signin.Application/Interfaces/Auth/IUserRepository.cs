using Signin.Domain.Entities.Auth;

namespace Signin.Application.Interfaces.Auth
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> FindUserByUsername(string username);
       

    }
}
