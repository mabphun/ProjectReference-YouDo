using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class UserTaskList
    {
        public string AppUserId { get; set; }

        [NotMapped]
        public virtual AppUser AppUser { get; set; }

        public string TaskListId { get; set; }

        [NotMapped]
        public virtual TaskList TaskList { get; set; }
    }
}