using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class TaskList
    {
        public string Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        [MaxLength(40, ErrorMessage = "Maximum length is 40")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Maximum length is 200")]
        public string Description { get; set; }
        
        //References
        public string CreatorId { get; set; }

        [NotMapped]
        public virtual AppUser Creator { get; set; }

        public virtual ICollection<TaskItem> Tasks { get; set; }

        public virtual ICollection<UserTaskList> AssignedMembers { get; set; }

        public TaskList()
        {
            Id = Guid.NewGuid().ToString();
            Tasks = new List<TaskItem>();
            AssignedMembers = new List<UserTaskList>();
        }
    }
}
