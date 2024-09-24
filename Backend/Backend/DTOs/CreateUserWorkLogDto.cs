namespace Backend.DTOs
{
    public class CreateUserWorkLogDto
    {
        public double WorkTimeInMins { get; set; }
        public string AppUserId { get; set; }
        public string TaskItemId { get; set; }
    }
}
