namespace Backend.DTOs
{
    public class CreateTaskListDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
    }
}
