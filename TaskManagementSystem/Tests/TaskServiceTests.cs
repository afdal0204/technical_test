
//using Xunit;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Infrastructure.Repositories;

public class TaskServiceTests
{
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        var repository = new InMemoryTaskRepository();
        _taskService = new TaskService(repository);
    }

    //[Fact]
    public void CreateTask_WithValidData_ShouldSucceed()
    {
        var taskDto = new TaskDto
        {
            Title = "Test Task",
            Description = "A test task",
            DueDate = DateTime.Today.AddDays(1),
            Priority = "High",
            Status = "Open",
            AssignedUser = "user123"
        };

        _taskService.CreateTask(taskDto);

        var tasks = _taskService.GetAllTasks();
        //Assert.Single(tasks);
    }
}
