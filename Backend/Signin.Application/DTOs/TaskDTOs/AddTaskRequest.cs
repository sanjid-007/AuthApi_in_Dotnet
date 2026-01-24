using Signin.Domain.Entities.UserTasks;

namespace Signin.Application.DTOs.TaskDTOs
{
    public class AddTaskRequest
    {
        public string? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public UserTaskStatus Status { get; set; }

        public string Priority { get; set; }


    }
  
}
