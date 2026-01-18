

using MongoDB.Driver;
using Signin.Application.Interfaces.UserTasks;
using Signin.Domain.Entities.UserTasks;
using Signin.Infrastructure.Data;

namespace Signin.Infrastructure.Repositories
{
    public class MongoUserTaskRepository : ITaskRepository
    {
        public readonly IMongoCollection<Task> _TasksCollection;
        public MongoUserTaskRepository(MongoDbContext context) {
            _TasksCollection = context.GetCollection<Task>("tasks");
        }
        public Task<UserTask> AddUserTask(UserTask userTask)
        {
            throw new NotImplementedException();
        }

        public Task<UserTask> GetUserTaskById(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserTask>> GetUserTasksByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveTask(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserTask> UpdateTask(UserTask userTask)
        {
            throw new NotImplementedException();
        }
    }
}
