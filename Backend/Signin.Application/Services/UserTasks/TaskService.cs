using Signin.Application.DTOs.TaskDTOs;
using Signin.Application.Interfaces.UserTasks;
using Signin.Domain.Entities.UserTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin.Application.Services.UserTasks
{
    public class TaskService : ITaskService
    {
        public readonly ITaskRepository _TaskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _TaskRepository = taskRepository;
        }

        public async Task<AddTaskResponse> AddTaskAsync(AddTaskRequest request, string userId)
        {
            var existingUserTask = await _TaskRepository.GetUserTaskById(request.Id,userId);
            if (existingUserTask != null)
            {
                throw new Exception("Task already exist");
            }
            var task = new UserTask
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                Status = request.Status,
                UserId = userId

            };
            var userTask = await _TaskRepository.AddUserTask(task);

            return new AddTaskResponse
            {
                Id = userTask.Id,
                Title = userTask.Title,
                Msg = "Success"
            };

        }

        public async Task<List<AllTasksResponse>> GetAllTasksAsync(string userId)
        {
            List<UserTask> userTasks = await _TaskRepository.GetUserTasksByUserId(userId);
            return userTasks.Select(t => new AllTasksResponse
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Msg = "Success"
            }).ToList();


        }

        public async Task<RemoveTaskResponse> RemoveTaskAsync(RemoveTaskRequest request, string userId)
        {
            var existingUserTask = await _TaskRepository.GetUserTaskById(request.Id, userId);
            if (existingUserTask == null)
            {
                throw new Exception("ALready Removed");
            }
            await _TaskRepository.RemoveTask(request.Id, userId);
            return new RemoveTaskResponse
            {
                Msg = "successfully removed"
            };

        }

        public async Task<UpdateTaskResponse> UpdateTaskAsync(UpdateTaskRequest request, string userId)
        {
            var userTask = await _TaskRepository.GetUserTaskById(request.Id, userId);
            userTask.Title = request.Title ?? userTask.Title;
            userTask.Description = request.Description ?? userTask.Description;

            var updatedUserTask = await _TaskRepository.UpdateTask(userTask);

            return new UpdateTaskResponse
            {
                Id = updatedUserTask.Id,
                Title = updatedUserTask.Title,
                Description = updatedUserTask.Description
            };


        }
    }

       
}
