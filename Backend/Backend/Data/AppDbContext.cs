using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Backend.Data
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();

        public DbSet<AppUser> Users { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }
        public DbSet<WorkflowItem> WorkflowItems { get; set; }
        public DbSet<UserWorkLog> UserWorkLogs { get; set; }
        public DbSet<UserTaskList> UserTaskLists { get; set; }
        public DbSet<UserConnection> UserConnections { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Relations
            //UserTaskList junction table
            builder.Entity<UserTaskList>()
                .HasKey(utl => new { utl.AppUserId, utl.TaskListId });

            builder.Entity<UserTaskList>()
                .HasOne(utl => utl.AppUser)
                .WithMany(u => u.AssignedTaskLists)
                .HasForeignKey(utl => utl.AppUserId);

            builder.Entity<UserTaskList>()
                .HasOne(utl => utl.TaskList)
                .WithMany(t => t.AssignedMembers)
                .HasForeignKey(utl => utl.TaskListId);

            //UserWorkLog junction table
            //builder.Entity<UserWorkLog>()
            //    .HasKey(uwl => new { uwl.AppUserId, uwl.TaskItemId });

            builder.Entity<UserWorkLog>()
                .HasOne(uwl => uwl.AppUser)
                .WithMany(u => u.LoggedWork)
                .HasForeignKey(uwl => uwl.AppUserId);

            builder.Entity<UserWorkLog>()
                .HasOne(uwl => uwl.TaskItem)
                .WithMany(u => u.LoggedWork)
                .HasForeignKey(uwl => uwl.TaskItemId);

            //TaskList
            builder.Entity<TaskList>()
                .HasMany(x => x.Tasks)
                .WithOne(x => x.TaskList)
                .HasForeignKey(x => x.TaskListId);

            //TaskItem
            builder.Entity<TaskItem>()
                .HasMany(x => x.WorkflowItems)
                .WithOne(x => x.TaskItem)
                .HasForeignKey(x => x.TaskItemId);

            builder.Entity<TaskItem>()
                .HasMany(x => x.ChangeLogs)
                .WithOne(x => x.TaskItem)
                .HasForeignKey(x => x.TaskItemId);


            #endregion;

            //Db Seeds

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            AppUser user1 = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                NormalizedUserName = "JOHN.DOE",
                NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                Image = "https://fastly.picsum.photos/id/237/200/200.jpg?hmac=zHUGikXUDyLCCmvyww1izLK3R3k8oRYBRiTizZEdyfI",
                UserName = "john.doe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
            };
            AppUser user2 = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                NormalizedUserName = "SARAH.SMITH",
                NormalizedEmail = "SARAH.SMITH@EXAMPLE.COM",
                Image = "https://fastly.picsum.photos/id/408/200/200.jpg?hmac=VJjKULX_XeyV5C9mbWyv6XTsG5EV-ZBsqbiQIi6xTeg",
                UserName = "sarah.smith",
                FirstName = "Sarah",
                LastName = "Smith",
                Email = "sarah.smith@example.com"
            };
            AppUser user3 = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                NormalizedUserName = "MIKE.JONES",
                NormalizedEmail = "MIKE.JONES@EXAMPLE.COM",
                Image = "https://fastly.picsum.photos/id/256/200/200.jpg?hmac=MX3r8Dktr5b26lQqb5JB6sgLnCxSgt1KRm0F1eNDHCk",
                UserName = "mike.jones",
                FirstName = "Mike",
                LastName = "Jones",
                Email = "mike.jones@example.com"
            };
            AppUser user4 = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                NormalizedUserName = "EMILY.WILLIAMS",
                NormalizedEmail = "EMILY.WILLIAMS@EXAMPLE.COM",
                Image = "https://fastly.picsum.photos/id/916/200/200.jpg?hmac=hEUrLG-ayFdIoyHKUwazT8SMEsVxWH9xGz4tx-e0cN0",
                UserName = "emily.williams",
                FirstName = "Emily",
                LastName = "Williams",
                Email = "emily.williams@example.com"
            };
            user1.PasswordHash = ph.HashPassword(user1, "user1234");
            user2.PasswordHash = ph.HashPassword(user2, "user1234");
            user3.PasswordHash = ph.HashPassword(user3, "user1234");
            user4.PasswordHash = ph.HashPassword(user4, "user1234");
            builder.Entity<AppUser>().HasData(user1, user2, user3, user4);

            TaskList tl1 = new TaskList()
            {
                Name = "Programming tasks",
                Description = "This list will contain programming tasks.",
                CreatorId = user1.Id,
            };
            TaskList tl2 = new TaskList()
            {
                Name = "Management tasks",
                Description = "This list will contain management type tasks.",
                CreatorId = user2.Id,
            };
            builder.Entity<TaskList>().HasData(tl1, tl2);


            TaskItem ti1 = new TaskItem()
            {
                Title = "Complete Report",
                Details = "Finish writing the quarterly report for the management team.",
                Priority = TaskItemPriority.Normal,
                Deadline = DateTime.Now.Date.AddDays(5).ToUniversalTime(),
                Estimated = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatorId = user1.Id,
                AssigneeId = user1.Id,
                TaskListId = tl1.Id,
            };
            TaskItem ti2 = new TaskItem()
            {
                Title = "Review Code Changes",
                Details = "Conduct a thorough review of the recent code changes in the development branch and provide feedback.",
                Priority = TaskItemPriority.High,
                Deadline = DateTime.Now.Date.AddDays(1).ToUniversalTime(),
                Estimated = 6,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatorId = user1.Id,
                AssigneeId = user3.Id,
                TaskListId = tl1.Id,
            };

            TaskItem ti3 = new TaskItem()
            {
                Title = "Call Client",
                Details = "Follow up with the client regarding their recent inquiries and provide necessary assistance.",
                Priority = TaskItemPriority.High,
                Deadline = DateTime.Now.Date.AddDays(2).ToUniversalTime(),
                Estimated = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatorId = user2.Id,
                AssigneeId = user4.Id,
                TaskListId = tl2.Id,
            };
            TaskItem ti4 = new TaskItem()
            {
                Title = "Schedule Meeting",
                Details = "Coordinate a meeting with the project team to discuss the upcoming milestones and action items.",
                Priority = TaskItemPriority.High,
                Deadline = DateTime.Now.Date.AddDays(4).ToUniversalTime(),
                Estimated = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatorId = user2.Id,
                AssigneeId = user4.Id,
                TaskListId = tl2.Id,
            };
            TaskItem ti5 = new TaskItem()
            {
                Title = "Research Market Trends",
                Details = "Research current market trends and gather insights to inform strategic decisions for the next quarter.",
                Priority = TaskItemPriority.Low,
                Deadline = DateTime.Now.Date.AddDays(10).ToUniversalTime(),
                Estimated = 20,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatorId = user2.Id,
                AssigneeId = user2.Id,
                TaskListId = tl2.Id,
            };

            builder.Entity<TaskItem>().HasData(ti1, ti2, ti3, ti4, ti5);


            WorkflowItem ti1wf1 = new WorkflowItem()
            {
                Name = "To Do",
                IsActive = true,
                Order = 0,
                TaskItemId = ti1.Id,
                IsDeletable = false,
            };

            WorkflowItem ti1wf2 = new WorkflowItem()
            {
                Name = "Done",
                IsActive = false,
                Order = 100,
                TaskItemId = ti1.Id,
                IsDeletable = false,
            };

            WorkflowItem ti2wf1 = new WorkflowItem()
            {
                Name = "To Do",
                IsActive = true,
                Order = 0,
                TaskItemId = ti2.Id,
                IsDeletable = false,
            };

            WorkflowItem ti2wf2 = new WorkflowItem()
            {
                Name = "Done",
                IsActive = false,
                Order = 100,
                TaskItemId = ti2.Id,
                IsDeletable = false,
            };

            WorkflowItem ti3wf1 = new WorkflowItem()
            {
                Name = "To Do",
                IsActive = true,
                Order = 0,
                TaskItemId = ti3.Id,
                IsDeletable = false,
            };

            WorkflowItem ti3wf2 = new WorkflowItem()
            {
                Name = "Done",
                IsActive = false,
                Order = 100,
                TaskItemId = ti3.Id,
                IsDeletable = false,
            };

            WorkflowItem ti4wf1 = new WorkflowItem()
            {
                Name = "To Do",
                IsActive = true,
                Order = 0,
                TaskItemId = ti4.Id,
                IsDeletable = false,
            };

            WorkflowItem ti4wf2 = new WorkflowItem()
            {
                Name = "Done",
                IsActive = false,
                Order = 100,
                TaskItemId = ti4.Id,
                IsDeletable = false,
            };

            WorkflowItem ti5wf1 = new WorkflowItem()
            {
                Name = "To Do",
                IsActive = true,
                Order = 0,
                TaskItemId = ti5.Id,
                IsDeletable = false,
            };

            WorkflowItem ti5wf2 = new WorkflowItem()
            {
                Name = "Done",
                IsActive = false,
                Order = 100,
                TaskItemId = ti5.Id,
                IsDeletable = false,
            };

            builder.Entity<WorkflowItem>().HasData(ti1wf1, ti1wf2, ti2wf1, ti2wf2, ti3wf1, ti3wf2, ti4wf1, ti4wf2, ti5wf1, ti5wf2);

            UserTaskList user1tl1 = new UserTaskList()
            {
                AppUserId = user1.Id,
                TaskListId = tl1.Id,
            };
            UserTaskList user1tl2 = new UserTaskList()
            {
                AppUserId = user1.Id,
                TaskListId = tl2.Id,
            };
            UserTaskList user3tl1 = new UserTaskList()
            {
                AppUserId = user3.Id,
                TaskListId = tl1.Id,
            };
            UserTaskList user2tl1 = new UserTaskList()
            {
                AppUserId = user2.Id,
                TaskListId = tl1.Id,
            };
            UserTaskList user2tl2 = new UserTaskList()
            {
                AppUserId = user2.Id,
                TaskListId = tl2.Id,
            };
            UserTaskList user4tl2 = new UserTaskList()
            {
                AppUserId = user4.Id,
                TaskListId = tl2.Id,
            };

            builder.Entity<UserTaskList>().HasData(user1tl1, user1tl2, user2tl1, user2tl2, user3tl1, user4tl2);

            UserWorkLog user1wl1 = new UserWorkLog()
            {
                AppUserId = user1.Id,
                TaskItemId = ti1.Id,
                LogDate = DateTime.UtcNow,
                WorkTime = TimeSpan.FromHours(1).Ticks,
            };
            UserWorkLog user3wl2 = new UserWorkLog()
            {
                AppUserId = user3.Id,
                TaskItemId = ti2.Id,
                LogDate = DateTime.UtcNow,
                WorkTime = TimeSpan.FromHours(2).Ticks,
            };
            UserWorkLog user1wl2 = new UserWorkLog()
            {
                AppUserId = user1.Id,
                TaskItemId = ti1.Id,
                LogDate = DateTime.UtcNow - new TimeSpan(8,0,0,0),
                WorkTime = TimeSpan.FromHours(5).Ticks,
            };

            builder.Entity<UserWorkLog>().HasData(user1wl1, user1wl2, user3wl2);

            base.OnModelCreating(builder);
        }
    }
}
