
using TaskManagementSystem.Application.DTOs;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface ITaskService
    {
        void CreateTask(TaskDto taskDto);
        void UpdateTask(Guid id, TaskDto taskDto);
        void DeleteTask(Guid id);
        IEnumerable<TaskDto> GetAllTasks();
        IEnumerable<TaskDto> GetTasksByUser(string userId);
    }
}
