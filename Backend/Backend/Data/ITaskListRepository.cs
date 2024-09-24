using Backend.DTOs;
using Backend.Models;

namespace Backend.Data
{
    public interface ITaskListRepository
    {
        Task<TaskList> CreateAsync(CreateTaskListDto createDto);
        Task DeleteAsync(string id, string callerId);
        Task<IEnumerable<TaskList>> ReadAsync();
        Task<TaskList> ReadAsync(string id);
        Task<TaskList> UpdateAsync(UpdateTaskListDto tasklistDto);
    }
}