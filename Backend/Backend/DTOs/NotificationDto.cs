namespace Backend.DTOs
{
    public class NotificationDto
    {
        public AppUserDto InitiatorUser { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string Action { get ; set; }
        public DateTime Time { get; set; }
    }
}
