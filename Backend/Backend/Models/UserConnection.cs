namespace Backend.Models
{
    public class UserConnection
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ConnectionId { get; set; }

        public UserConnection()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
