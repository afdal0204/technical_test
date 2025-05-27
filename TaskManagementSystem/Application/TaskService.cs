
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public void CreateTask(TaskDto taskDto)
        {
            if (taskDto.DueDate < DateTime.Today)
                throw new ArgumentException("Due date cannot be in the past.");

            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Priority = taskDto.Priority,
                Status = taskDto.Status,
                AssignedUser = taskDto.AssignedUser
            };

            _repository.Add(task);
        }

        public void UpdateTask(Guid id, TaskDto taskDto)
        {
            var task = _repository.GetById(id);
            if (task == null) throw new KeyNotFoundException("Task not found");

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.DueDate = taskDto.DueDate;
            task.Priority = taskDto.Priority;
            task.Status = taskDto.Status;
            task.AssignedUser = taskDto.AssignedUser;

            _repository.Update(task);
        }

        public void DeleteTask(Guid id) => _repository.Delete(id);

        public IEnumerable<TaskDto> GetAllTasks() =>
            _repository.GetAll().Select(t => new TaskDto
            {
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority,
                Status = t.Status,
                AssignedUser = t.AssignedUser
            });

        public IEnumerable<TaskDto> GetTasksByUser(string userId) =>
            _repository.GetByUser(userId).Select(t => new TaskDto
            {
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority,
                Status = t.Status,
                AssignedUser = t.AssignedUser
            });
    }
}
