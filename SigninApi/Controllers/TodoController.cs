using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Signin.Application.DTOs.TaskDTOs;
using Signin.Application.Interfaces;
using Signin.Application.Interfaces.UserTasks;
using System.Security.Claims;

namespace Signin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly ITaskService _TaskService;
        public TodoController(ITaskService taskService)
        {
            _TaskService = taskService;
        }
        [Authorize]
        [HttpPost("add-Task")]
        public async Task<IActionResult> AddTask([FromBody] AddTaskRequest dto)
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var result = await _TaskService.AddTaskAsync(dto,id);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Rip Add Task");
            }
        }
        [Authorize]
        [HttpPost("update-task")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequest dto)
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _TaskService.UpdateTaskAsync(dto,id);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Rip Update Task");
            }
        }
        [Authorize]
        [HttpPost("remove-task")]
        public async Task<IActionResult> RemoveTask([FromBody] RemoveTaskRequest dto)
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _TaskService.RemoveTaskAsync(dto,id);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Rip Remove Task");
            }
        }
        [Authorize]
        [HttpGet("all-tasks")]
        public async Task<IActionResult> GetALlTasks()
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _TaskService.GetAllTasksAsync(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Rip all Tasks");
            }
        }


        

    }
}
