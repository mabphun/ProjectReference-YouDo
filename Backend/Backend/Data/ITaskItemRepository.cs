using Backend.DTOs;
using Backend.Models;

namespace Backend.Data
{
    public interface ITaskItemRepository
    {
        Task<TaskItem> CreateAsync(CreateTaskItemDto taskItemDto);
        Task DeleteAsync(string id);
        Task<IEnumerable<TaskItem>> ReadAsync();
        Task<TaskItem> ReadAsync(string id);
        Task<IEnumerable<TaskItem>> GetCreatedTaskItems(string userid);
        Task<TaskItem> UpdateAsync(TaskItem taskItems);
        Task<TaskItem> UpdateAsync(UpdateTaskItemDto taskItemDto);
    }
}