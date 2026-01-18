using Signin.Application.DTOs.TaskDTOs;

namespace Signin.Application.Interfaces.UserTasks
{
    public interface ITaskService
    {
        Task<AddTaskResponse> AddTaskAsync(AddTaskRequest request, string userId);
        Task<UpdateTaskResponse> UpdateTaskAsync(UpdateTaskRequest request, string userId);
        Task<RemoveTaskResponse> RemoveTaskAsync(RemoveTaskRequest request, string userId);
        Task<List<AllTasksResponse>> GetAllTasksAsync(string userId);
    }
}
