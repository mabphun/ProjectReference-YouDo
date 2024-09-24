using Backend.DTOs;
using Backend.Models;

namespace Backend.Data
{
    public interface IUserWorkLogRepository
    {
        Task<UserWorkLog> CreateAsync(CreateUserWorkLogDto createDto);
        Task<IEnumerable<UserWorkLog>> GetUsersWorkLogsAsync(string userid);
        void Delete(string appUserId, string taskItemId);
        Task<IEnumerable<UserWorkLog>> ReadAsync();
        Task<UserWorkLog> ReadAsync(string id);
        Task<UserWorkLog> ReadAsync(string appUserId, string taskItemId);
        void Update(UserWorkLog userWorkLog);
    }
}