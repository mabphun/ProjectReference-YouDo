using Backend.Models;

namespace Backend.DTOs
{
    public class TaskListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }

        //References
        //public string CreatorId { get; set; }
        public virtual AppUserDto Creator { get; set; }
        public virtual ICollection<TaskItemDto> Tasks { get; set; }
        public virtual ICollection<AppUserDto> AssignedMembers { get; set; }
    }
}
