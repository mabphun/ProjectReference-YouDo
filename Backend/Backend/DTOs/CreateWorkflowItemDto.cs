namespace Backend.DTOs
{
    public class CreateWorkflowItemDto
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string TaskItemId { get; set; }
    }
}
