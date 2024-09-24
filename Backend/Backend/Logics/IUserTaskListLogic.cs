using Backend.Models;

namespace Backend.Logics
{
    public interface IUserTaskListLogic
    {
        Task CreateAsync(UserTaskList userTaskList);
        Task DeleteAsync(string appUserId, string taskListId);
        Task<IEnumerable<UserTaskList>> ReadAsync();
        Task<UserTaskList> ReadAsync(string appUserId, string taskListId);
        //void Update(UserTaskList userTaskList);
    }
}