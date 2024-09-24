using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class WorkflowItem
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeletable { get; set; }

        //References

        public string TaskItemId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual TaskItem? TaskItem { get; set; }

        public WorkflowItem()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}