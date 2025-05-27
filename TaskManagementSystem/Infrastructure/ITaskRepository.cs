
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        void Add(TaskItem task);
        void Update(TaskItem task);
        void Delete(Guid id);
        TaskItem GetById(Guid id);
        IEnumerable<TaskItem> GetAll();
        IEnumerable<TaskItem> GetByUser(string userId);
    }
}
