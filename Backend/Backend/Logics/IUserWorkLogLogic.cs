using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public interface IUserWorkLogLogic
    {
        Task<UserWorkLog> CreateAsync(CreateUserWorkLogDto createDto);
        Task<IEnumerable<UserWorkLog>> GetUsersWorkLogsAsync(string userid);
        void Delete(string appUserId, string taskItemId);
        Task<IEnumerable<UserWorkLog>> ReadAsync();
        Task<UserWorkLog> ReadAsync(string appUserId, string taskItemId);
        void Update(UserWorkLog userWorkLog);
        Task<double> GetTotalWorkTimeAsync(string userid);
    }
}