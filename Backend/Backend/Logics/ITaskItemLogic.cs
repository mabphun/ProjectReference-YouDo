using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public interface ITaskItemLogic
    {
        Task<TaskItem> CreateAsync(CreateTaskItemDto taskItemDto);
        Task DeleteAsync(string id);
        Task<IEnumerable<TaskItem>> ReadAsync();
        Task<TaskItem> ReadAsync(string id);
        Task<IEnumerable<TaskItem>> GetCreatedTaskItems(string userid);
        Task<TaskItem> UpdateAsync(TaskItem taskItem);
        Task<TaskItem> UpdateAsync(UpdateTaskItemDto taskItemDto);
        Task<IEnumerable<TaskItem>> GetAuthorizedTaskItemsBySpecifiedWorkflowAsync(string userid, int wfOrder);
    }
}