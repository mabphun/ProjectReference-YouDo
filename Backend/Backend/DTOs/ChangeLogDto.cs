using Backend.Models;

namespace Backend.DTOs
{
    public class ChangeLogDto
    {
        public string Id { get; set; }
        public DateTime ChangeDate { get; set; }
        public string TaskItemId { get; set; }
        public AppUserDto Changer { get; set; }

        // Task properties
        public string OldTitle { get; set; }
        public string OldDetails { get; set; }
        public string OldPriority { get; set; }
        public string OldDeadline { get; set; }
        public string OldAssigneeId { get; set; }
        public AppUserDto OldAssignee { get; set; }
        public WorkflowItem OldWorkflowItem { get; set; }

        public string NewTitle { get; set; }
        public string NewDetails { get; set; }
        public string NewPriority { get; set; }
        public string NewDeadline { get; set; }
        public string NewAssigneeId { get; set; }
        public AppUserDto NewAssignee { get; set; }
        public WorkflowItem NewWorkflowItem { get; set; }
    }
}
