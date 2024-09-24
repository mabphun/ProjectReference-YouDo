using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public interface ITaskListLogic
    {
        Task<TaskList> CreateAsync(CreateTaskListDto createDto);
        Task DeleteAsync(string id, string callerId);
        Task<IEnumerable<TaskList>> ReadAsync();
        Task<TaskList> ReadAsync(string id);
        Task<TaskList> UpdateAsync(UpdateTaskListDto taskListDto);
        Task<IEnumerable<TaskList>> GetAuthorizedTaskListsAsync(string userId);
        Task<TaskList> GetAuthorizedTaskListAsync(string userId, string listId);

    }
}