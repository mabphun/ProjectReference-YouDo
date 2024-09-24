namespace Backend.DTOs
{
    public class UserWorkLogDto
    {
        public double WorkTimeInMins { get; set; }
        public AppUserDto AppUser { get; set; }
        public TaskItemDto TaskItem { get; set; }
        public DateTime LogDate { get; set; }
    }
}
