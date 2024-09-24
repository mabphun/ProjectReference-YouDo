using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class ChangeLog
    {
        public string Id { get; set; }
        public DateTime ChangeDate { get; set; }
        public string TaskItemId { get; set; }
        public string ChangerId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual AppUser Changer { get; set; }
        
        [NotMapped]
        public virtual TaskItem TaskItem { get; set; }

        // Task properties
        public string OldTitle { get; set; }
        public string OldDetails { get; set; }
        public TaskItemPriority OldPriority { get; set; }
        public DateTime OldDeadline { get; set; }
        public string OldAssigneeId { get; set; }
        public string OldWorkflowItemId { get; set; }

        public string NewTitle { get; set; }
        public string NewDetails { get; set; }
        public TaskItemPriority NewPriority { get; set; }
        public DateTime NewDeadline { get; set; }
        public string NewAssigneeId { get; set; }
        public string NewWorkflowItemId { get; set; }

        public ChangeLog()
        {
            Id = Guid.NewGuid().ToString();
            ChangeDate = DateTime.UtcNow;
        }
    }
}
