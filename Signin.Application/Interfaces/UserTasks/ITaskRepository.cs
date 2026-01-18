using Signin.Domain.Entities.UserTasks;
namespace Signin.Application.Interfaces.UserTasks
{
    public interface ITaskRepository
    {
        Task<UserTask> AddUserTask(UserTask userTask);
        Task<List<UserTask>> GetUserTasksByUserId(string id);

        Task<UserTask> GetUserTaskById(string id, string userId);

        Task RemoveTask(string id, string userId);

        Task<UserTask> UpdateTask(UserTask userTask);

    }
}
