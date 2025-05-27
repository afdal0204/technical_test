
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new();

        public void Add(TaskItem task) => _tasks.Add(task);

        public void Update(TaskItem task)
        {
            var index = _tasks.FindIndex(t => t.Id == task.Id);
            if (index >= 0)
                _tasks[index] = task;
        }

        public void Delete(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                _tasks.Remove(task);
        }

        public TaskItem GetById(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);

        public IEnumerable<TaskItem> GetAll() => _tasks;

        public IEnumerable<TaskItem> GetByUser(string userId) =>
            _tasks.Where(t => t.AssignedUser == userId);
    }
}
