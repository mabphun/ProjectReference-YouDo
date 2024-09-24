using Backend.Models;

namespace Backend.DTOs
{
    public class TaskItemDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public TaskItemPriority Priority { get; set; }
        public DateTime? Deadline { get; set; }
        public float Estimated { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AppUserDto Creator { get; set; }
        public AppUserDto Assignee { get; set; }
        public ICollection<WorkflowItem> WorkflowItems { get; set; }
        public ICollection<ChangeLogDto> ChangeLogs { get; set; }
        public ICollection<UserWorkLogDto> UserWorkLogs { get; set; }
        public string TaskListId { get; set; }
        public TaskListDto TaskList { get; set; }
    }
}
