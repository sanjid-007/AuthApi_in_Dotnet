
using Signin.Domain.Entities;

namespace Signin.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> FindUserByUsername(string username);
       

    }
}
