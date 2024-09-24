using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Backend.Data
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly AppDbContext _context;

        private readonly IWorkflowItemRepository _workflowItemRepository;

        public TaskItemRepository(AppDbContext context, IWorkflowItemRepository workflowItemRepository)
        {
            _context = context;
            _workflowItemRepository = workflowItemRepository;
        }

        /*
        public async Task CreateAsync(TaskItem taskItems)
        {
            var old = _context.TaskItems.FirstOrDefault(t => t.Id == taskItems.Id);
            if (old != null)
            {
                throw new ArgumentException("There's already a taskItems with this id: " + taskItems.Id);
            }

            _context.TaskItems.Add(taskItems);
            await _context.SaveChangesAsync();
        }*/

        public async Task<TaskItem> CreateAsync(CreateTaskItemDto itemDto)
        {
            
            var taskItem = new TaskItem()
            {
                Title = itemDto.Title,
                Details = itemDto.Details,
                Deadline = DateTime.Parse(itemDto.Deadline).ToUniversalTime(),
                Estimated = itemDto.Estimated,
                Priority = (TaskItemPriority)int.Parse(itemDto.Priority),

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                //Assignee = creator,
                AssigneeId = itemDto.CreatorId,
                //Creator = creator,
                CreatorId = itemDto.CreatorId,
                //LoggedWork = new List<UserWorkLog>(),
                //TaskList = taskList,
                TaskListId = itemDto.TaskListId,
                //WorkflowItems = new List<WorkflowItem>()
            };
            taskItem.WorkflowItems.Add(
                new WorkflowItem
                {
                    Name = "To Do",
                    IsActive = true,
                    Order = 0,
                    TaskItemId = taskItem.Id,
                    TaskItem = taskItem,
                    IsDeletable = false,
                });
                taskItem.WorkflowItems.Add(
                new WorkflowItem
                {
                    Name = "Done",
                    IsActive = false,
                    Order = 100,
                    TaskItemId = taskItem.Id,
                    TaskItem = taskItem,
                    IsDeletable = false,
                }
            );

            var old = _context.TaskItems.FirstOrDefault(t => t.Id == taskItem.Id);
            if (old != null)
            {
                throw new ArgumentException("There's already a taskItems with this id: " + taskItem.Id);
            }
            
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            taskItem = await ReadAsync(taskItem.Id);
            return taskItem;
        }

        public async Task<IEnumerable<TaskItem>> ReadAsync()
        {
            return await _context.TaskItems.Include(x=> x.TaskList).ToListAsync();
        }

        public async Task<TaskItem> ReadAsync(string id)
        {
            var taskItem = await _context.TaskItems
                .Include(x => x.TaskList)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (taskItem == null)
            {
                throw new ArgumentException("There's no Task with this id: " + id);
            }
            return taskItem;
        }

        public async Task<IEnumerable<TaskItem>> GetCreatedTaskItems(string userid)
        {
            var tasks = await ReadAsync();

            return tasks.Where(x=> x.CreatorId == userid);
        }

        public async Task DeleteAsync(string id)
        {
            var taskItem = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (taskItem == null)
            {
                throw new ArgumentException("There's no Task Item with this id: " + id);
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskItem> UpdateAsync(UpdateTaskItemDto dto)
        {
            
            var old = await _context.TaskItems.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (old == null) throw new ArgumentException("There's no TaskItem with this id: " + dto.Id);

            old.Title = dto.Title;
            old.Details = dto.Details;
            old.Priority = (TaskItemPriority)int.Parse(dto.Priority);
            old.Deadline = dto.Deadline.ToUniversalTime();
            old.AssigneeId = dto.AssigneeId;
            old.UpdatedAt = DateTime.UtcNow;
            

            foreach (var item in dto.WorkflowItems)
            {
                var oldItem = await _context.WorkflowItems.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (oldItem == null) throw new ArgumentException("There's no WorkflowItem with this id: " + item.Id);
                oldItem.Name = item.Name;
                oldItem.Order = item.Order;
                oldItem.IsActive = item.IsActive;
                
            }

            
            await _context.SaveChangesAsync();
            return old;
        }

        public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
        {
            ;
            var newItem = new TaskItem()
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Details = taskItem.Details,
                Priority = taskItem.Priority,
                Deadline = taskItem.Deadline,
                AssigneeId = taskItem.AssigneeId,
            };
            foreach (var wf in taskItem.WorkflowItems)
            {
                newItem.WorkflowItems.Add(wf);
            }
            ;
            var old = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == newItem.Id);
            if (old == null) throw new ArgumentException("There's no Task Item with this id: " + taskItem.Id);
            ;
            old.Title = newItem.Title;
            old.Details = newItem.Details;
            old.Priority = newItem.Priority;
            old.Deadline = newItem.Deadline;
            old.AssigneeId = newItem.AssigneeId;
            old.UpdatedAt = DateTime.UtcNow;
            ;
            foreach (var item in newItem.WorkflowItems)
            {
                var oldItem = await _context.WorkflowItems.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (oldItem == null) throw new ArgumentException(item.Id + " does not match with any workflow item's id.");
                oldItem.Name = item.Name;
                oldItem.Order = item.Order;
                oldItem.IsActive = item.IsActive;
                ;
            }
            ;
            await _context.SaveChangesAsync();

            return old;
        }


        //public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
        //{
        //    ;
        //    var old = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == taskItem.Id);
        //    if (old == null)
        //    {
        //        throw new ArgumentException("There's no Task Item with this id: " + taskItem.Id);
        //    }
        //    ;


        //    old.Title = taskItem.Title;
        //    old.Details = taskItem.Details;
        //    old.Priority = taskItem.Priority;
        //    old.Deadline = taskItem.Deadline;
        //    old.UpdatedAt = taskItem.UpdatedAt;
        //    old.AssigneeId = taskItem.AssigneeId;
        //    //old.WorkflowItems.Clear();
        //    ;
        //    await _context.SaveChangesAsync();

        //    //foreach (var newWfItem in taskItem.WorkflowItems)
        //    //{
        //    //    old.WorkflowItems.Add(newWfItem);
        //    //}

        //    //WorkflowItem wf = new WorkflowItem() { Name = "asd", ColorCode = "", IsActive = false};

        //    ////_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        //    //;
        //    //await _context.SaveChangesAsync();
        //    return old;
        //}
    }
}
