
namespace TaskManagementSystem.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string AssignedUser { get; set; }
    }
}
