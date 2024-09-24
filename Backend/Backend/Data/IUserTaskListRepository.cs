using Backend.Models;

namespace Backend.Data
{
    public interface IUserTaskListRepository
    {
        Task CreateAsync(UserTaskList userTaskLists);
        Task DeleteAsync(string appUserId, string taskItemId);
        Task<IEnumerable<UserTaskList>> ReadAsync();
        Task<UserTaskList> ReadAsync(string appUserId, string taskItemId);
        //void Update(UserTaskList userTaskLists);
    }
}