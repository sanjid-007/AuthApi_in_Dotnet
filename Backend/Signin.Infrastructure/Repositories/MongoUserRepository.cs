

using MongoDB.Driver;
using Signin.Application.Interfaces.Auth;
using Signin.Domain.Entities.Auth;
using Signin.Infrastructure.Data;

namespace Signin.Infrastructure.Repositories
{
    public class MongoUserRepository : IUserRepository
    {
        public readonly IMongoCollection<User> _usersCollection;
        public MongoUserRepository(MongoDbContext mongoDbContext) {
            _usersCollection = mongoDbContext.GetCollection<User>("Users");

        }
        public async Task<User> CreateUser(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            return user;
        }

        public async Task<User> FindUserByUsername(string username)
        {
           var user = await _usersCollection.Find(u => u.Username == username).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            await _usersCollection.ReplaceOneAsync(e => e.Id == user.Id,user);
            return user;
        }
    }
}
