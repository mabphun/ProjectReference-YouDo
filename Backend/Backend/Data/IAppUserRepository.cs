using Backend.Models;

namespace Backend.Data
{
    public interface IAppUserRepository
    {
        void Create(AppUser user);
        void Delete(string id);
        Task<IEnumerable<AppUser>> GetUsersByQueryAsync(string query);
        Task<IEnumerable<AppUser>> ReadAsync();
        Task<AppUser> ReadAsync(string id);
        void Update(AppUser user);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<AppUser> GetUserByIdAsync(string userid);
    }
}