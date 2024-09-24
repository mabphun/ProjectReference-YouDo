using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class AppUser : IdentityUser
    {
        public string? Image { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //References
        public virtual ICollection<UserTaskList>? AssignedTaskLists { get; set; }

        public virtual ICollection<UserWorkLog>? LoggedWork { get; set; }

        public AppUser()
        {
            AssignedTaskLists = new List<UserTaskList>();
            LoggedWork = new List<UserWorkLog>();
        }

    }
}