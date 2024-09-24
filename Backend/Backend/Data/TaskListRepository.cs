using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly AppDbContext _context;
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskListRepository(AppDbContext context, ITaskItemRepository taskItemRepository)
        {
            _context = context;
            _taskItemRepository = taskItemRepository;
        }

        public async Task<TaskList> CreateAsync(CreateTaskListDto createDto)
        {
            var taskList = new TaskList()
            {
                Name = createDto.Name,
                Description = createDto.Description,
                CreatorId = createDto.CreatorId,
                AssignedMembers = new List<UserTaskList>(),
                Tasks = new List<TaskItem>()
            };
            UserTaskList utl = new UserTaskList()
            {
                AppUserId = createDto.CreatorId,
                TaskListId = taskList.Id
            };
            taskList.AssignedMembers.Add(utl);
            var old = _context.TaskLists.FirstOrDefault(t => t.Id == taskList.Id);
            if (old != null)
            {
                throw new ArgumentException("There's already a tasklist with this id: " + taskList.Id);
            }
            
            _context.TaskLists.Add(taskList);
            await _context.SaveChangesAsync();
            
            var resp = await ReadAsync(taskList.Id);
            resp.AssignedMembers = await _context.UserTaskLists
                .Where(x => x.TaskListId == resp.Id)
                .Include(x => x.AppUser)
                .Include(x => x.TaskList)
                .ToListAsync();
            
            return resp;
        }

        public async Task<IEnumerable<TaskList>> ReadAsync()
        {
            return await _context.TaskLists
                .ToListAsync();
        }

        public async Task<TaskList> ReadAsync(string id)
        {
            var tasklist = await _context.TaskLists
                .FirstOrDefaultAsync(t => t.Id == id);
            if (tasklist == null)
            {
                throw new ArgumentException("There's no tasklist with this id: " + id);
            }
            return tasklist;
        }

        public async Task DeleteAsync(string id, string callerId)
        {
            var tasklist = _context.TaskLists.FirstOrDefault(t => t.Id == id);
            if (tasklist == null) throw new ArgumentException("There's no tasklist with this id: " + id);
            if (tasklist.CreatorId != callerId) throw new InvalidOperationException("Only the creator of the list can delete it.");
            //if (tasklist.Tasks.Count > 0) throw new ArgumentException("This task list has at least one task, so it is cannot be deleted.");

            _context.TaskLists.Remove(tasklist);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskList> UpdateAsync(UpdateTaskListDto tasklistDto)
        {
            //var old = _context.TaskLists.FirstOrDefault(t => t.Id == tasklistDto.Id);
            var old = await ReadAsync(tasklistDto.Id);
            
            if (old == null)
            {
                throw new ArgumentException("There's no tasklist with this id: " + tasklistDto.Id);
            }
            old.Name = tasklistDto.Name;
            old.Description = tasklistDto.Description;

            //Remove
            var membersToRemove = new List<UserTaskList>();
            foreach (var oldmember in old.AssignedMembers)
            {
                if (tasklistDto.AssignedMembers
                    .Where(x=> x.Id == oldmember.AppUserId)
                    .FirstOrDefault() == null)
                {
                    if (old.Tasks.Any(task => 
                        task.AssigneeId == oldmember.AppUserId || 
                        task.CreatorId == oldmember.AppUserId || 
                        task.ChangeLogs.Any(changeLog => changeLog.ChangerId == oldmember.AppUserId)))
                    {
                        var username = old.AssignedMembers.FirstOrDefault(x => x.AppUserId == oldmember.AppUserId)?.AppUser.UserName;
                        throw new BadHttpRequestException("Cannot remove '" + username + "' user from this list, becuase there's task items created by or assigned to this user or they already made changes to tasks.");
                    }
                    else membersToRemove.Add(oldmember);
                }
            }
            foreach (var member in membersToRemove)
            {
                old.AssignedMembers.Remove(member);
            }

            //Add
            var membersToAdd = new List<UserTaskList>();
            foreach (var newmember in tasklistDto.AssignedMembers)
            {
                if (old.AssignedMembers
                    .Where(x=> x.AppUserId == newmember.Id)
                    .FirstOrDefault() == null)
                {
                    var utl = new UserTaskList()
                    {
                        AppUserId = newmember.Id,
                        TaskListId = old.Id
                    };
                    membersToAdd.Add(utl);
                }
            }
            foreach (var member in membersToAdd)
            {
                old.AssignedMembers.Add(member);
            }
            
            await _context.SaveChangesAsync();
            var result = await ReadAsync(old.Id);
            result.AssignedMembers = await _context.UserTaskLists
                .Where(x=> x.TaskListId == result.Id)
                .Include(x=> x.AppUser)
                .Include(x=> x.TaskList)
                .ToListAsync();
            
            return result;
        }
    }
}
