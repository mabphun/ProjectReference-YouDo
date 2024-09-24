namespace Backend.DTOs
{
    public class UpdateTaskListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AppUserDto> AssignedMembers { get; set; }
    }
}
