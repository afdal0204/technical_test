
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Application.DTOs
{
    public class TaskDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string AssignedUser { get; set; }
    }
}
