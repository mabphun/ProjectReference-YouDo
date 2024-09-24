using Backend.Models;

namespace Backend.DTOs
{
    public class CreateTaskItemDto
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string Priority { get; set; }
        public string Deadline { get; set; }
        public float Estimated { get; set; }
        public string TaskListId { get; set; }
        public string CreatorId { get; set; }
    }
}
