using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class UserTaskListRepository : IUserTaskListRepository
    {
        private readonly AppDbContext _context;

        public UserTaskListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserTaskList userTaskLists)
        {
            var old = await _context.UserTaskLists.FirstOrDefaultAsync(t => t.AppUserId == userTaskLists.AppUserId && t.TaskListId == userTaskLists.TaskListId);
            if (old != null)
            {
                throw new ArgumentException("This user UserId: " + userTaskLists.AppUserId + " is already connected with this TaskListId: " + userTaskLists.TaskListId);
            }
            await _context.UserTaskLists.AddAsync(userTaskLists);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserTaskList>> ReadAsync()
        {
            return await _context.UserTaskLists.ToListAsync();
        }

        public async Task<UserTaskList> ReadAsync(string appUserId, string taskItemId)
        {
            var userTaskList = await _context.UserTaskLists.FirstOrDefaultAsync(t => t.AppUserId == appUserId && t.TaskListId == taskItemId);
            if (userTaskList == null)
            {
                throw new ArgumentException("There's no UserTaskList with this UserId: " + appUserId + " and with this TaskListId: " + taskItemId);
            }
            return userTaskList;
        }

        public async Task DeleteAsync(string appUserId, string taskItemId)
        {
            var userTaskList = _context.UserTaskLists.FirstOrDefault(t => t.AppUserId == appUserId && t.TaskListId == taskItemId);
            if (userTaskList == null)
            {
                throw new ArgumentException("There's no UserTaskList with this UserId: " + appUserId + " and with this TaskListId: " + taskItemId);
            }
            bool isUserCreatorOrAssignee = userTaskList.TaskList.Tasks
                .Where(x=>x.CreatorId == appUserId || x.AssigneeId == appUserId).Any();
            if (isUserCreatorOrAssignee)
            {
                throw new BadHttpRequestException("Cannot remove user from this list, becuase there's task items created or assigned to this user.");
            }

            _context.UserTaskLists.Remove(userTaskList);
            await _context.SaveChangesAsync();
        }

        //public void Update(UserTaskList userTaskLists)
        //{
        //    var old = _context.UserTaskLists.FirstOrDefault(t => t.AppUserId == userTaskLists.AppUserId && t.TaskListId == userTaskLists.TaskListId);
        //    if (old == null)
        //    {
        //        throw new ArgumentException("There's no UserTaskList with this UserId: " + userTaskLists.AppUserId + " and with this TaskListId: " + userTaskLists.TaskListId);
        //    }

        //    _context.SaveChanges();
        //}
    }
}
