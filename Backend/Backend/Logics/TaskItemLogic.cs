using Backend.Data;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public class TaskItemLogic : ITaskItemLogic
    {
        private readonly ITaskItemRepository _taskItemRepo;
        //private readonly IWorkflowItemRepository _workflowItemRepo;

        public TaskItemLogic(ITaskItemRepository repo)
        {
            _taskItemRepo = repo;
            //_workflowItemRepo = workflowItemRepo;
        }

        public async Task<TaskItem> CreateAsync(CreateTaskItemDto taskItemDto)
        {
            var taskItem = await _taskItemRepo.CreateAsync(taskItemDto);
            return taskItem;
        }

        public async Task<IEnumerable<TaskItem>> ReadAsync()
        {
            return await _taskItemRepo.ReadAsync();
        }

        public async Task<TaskItem> ReadAsync(string id)
        {
            return await _taskItemRepo.ReadAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAuthorizedTaskItemsBySpecifiedWorkflowAsync(string userid, int wfOrder)
        {
            var allItems = await _taskItemRepo.ReadAsync();
            

            var filtered = allItems.Where(item => item.TaskList.AssignedMembers.Any(x => x.AppUserId == userid)
            && item.WorkflowItems.Any(x => x.IsActive && x.Order == wfOrder));
            
            return filtered;
        }

        public async Task<IEnumerable<TaskItem>> GetCreatedTaskItems(string userid)
        {
            return await _taskItemRepo.GetCreatedTaskItems(userid);
        }

        public async Task DeleteAsync(string id)
        {
            await _taskItemRepo.DeleteAsync(id);
        }

        public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
        {
            ;
            taskItem.UpdatedAt = DateTime.UtcNow;
            var updatedItem = await _taskItemRepo.UpdateAsync(taskItem);

            return updatedItem;
        }

        public async Task<TaskItem> UpdateAsync(UpdateTaskItemDto dto)
        {
            
            var updatedItem = await _taskItemRepo.UpdateAsync(dto);

            return updatedItem;
        }
    }
}
