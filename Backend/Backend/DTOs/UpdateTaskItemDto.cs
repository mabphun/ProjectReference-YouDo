using Backend.Models;

namespace Backend.DTOs
{
    public class UpdateTaskItemDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public string AssigneeId { get; set; }
        public ICollection<WorkflowItem> WorkflowItems { get; set; }
    }
}
