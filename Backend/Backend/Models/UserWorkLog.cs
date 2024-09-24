using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class UserWorkLog
    {
        public string Id { get; set; }

        public DateTime LogDate { get; set; }

        public long WorkTime { get; set; }

        //References
        public string AppUserId { get; set; }

        [NotMapped]
        public virtual AppUser? AppUser { get; set; }

        public string TaskItemId { get; set; }

        [NotMapped]
        public virtual TaskItem? TaskItem { get; set; }

        public UserWorkLog()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}