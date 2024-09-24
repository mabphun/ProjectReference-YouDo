using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public enum TaskItemPriority
    {
        Low = 0,
        Normal = 1,
        High = 2
    }
    public class TaskItem
    {
        public string Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100")]
        public string Title { get; set; }

        [MaxLength(4000, ErrorMessage = "Maximum length is 4000")]
        public string Details { get; set; }
        public TaskItemPriority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public float Estimated { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //References
        public string CreatorId { get; set; }

        [NotMapped]
        public virtual AppUser Creator { get; set;}

        public string AssigneeId { get; set; }

        [NotMapped]
        public virtual AppUser Assignee { get; set; }

        public string TaskListId { get; set; }

        [NotMapped]
        public virtual TaskList TaskList { get; set; }
        
        public virtual ICollection<WorkflowItem> WorkflowItems { get; set; }

        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserWorkLog> LoggedWork { get; set; }

        public TaskItem()
        {
            Id = Guid.NewGuid().ToString();
            LoggedWork = new List<UserWorkLog>();
            WorkflowItems = new List<WorkflowItem>();
            ChangeLogs = new List<ChangeLog>();
        }

    }
}