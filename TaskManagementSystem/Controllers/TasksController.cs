
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Interfaces;

namespace TaskManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAllTasks() => Ok(_taskService.GetAllTasks());

        [HttpGet("{userId}")]
        public IActionResult GetTasksByUser(string userId) => Ok(_taskService.GetTasksByUser(userId));

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _taskService.CreateTask(taskDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody] TaskDto taskDto)
        {
            _taskService.UpdateTask(id, taskDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            _taskService.DeleteTask(id);
            return Ok();
        }
    }
}
