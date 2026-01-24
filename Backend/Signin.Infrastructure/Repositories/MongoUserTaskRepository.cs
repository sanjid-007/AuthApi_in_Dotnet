using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Signin.Application.Interfaces.UserTasks;
using Signin.Domain.Entities.UserTasks;
using Signin.Infrastructure.Data;

namespace Signin.Infrastructure.Repositories
{
    public class MongoUserTaskRepository : ITaskRepository
    {
        public readonly IMongoCollection<UserTask> _TasksCollection;
        public MongoUserTaskRepository(MongoDbContext context) {
            _TasksCollection = context.GetCollection<UserTask>("Tasks");
        }
        public async Task<UserTask> AddUserTask(UserTask userTask)
        {
            await _TasksCollection.InsertOneAsync(userTask);
            return userTask;

        }

        public async Task<UserTask> GetUserTaskById(string id, string userId)
        {
           var userTask =  await _TasksCollection.AsQueryable().Where(e => e.Id == id && e.UserId == userId).FirstOrDefaultAsync();
            return userTask;
        }

        public async Task<List<UserTask>> GetUserTasksByUserId(string userId)
        {
           var userTasks = await _TasksCollection.AsQueryable().Where(e => e.UserId == userId).ToListAsync();
            return userTasks;
        }

        public async Task RemoveTask(string id, string userId)
        {
            var w = await _TasksCollection.DeleteOneAsync(e => e.Id == id && e.UserId == userId);
        }

        public async Task<UserTask> UpdateTask(UserTask userTask)
        {
            await _TasksCollection.ReplaceOneAsync(e => e.Id == userTask.Id && e.UserId == userTask.UserId, userTask);
            return userTask;
        }
    }
}
