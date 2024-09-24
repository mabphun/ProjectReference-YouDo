using Backend.Models;

namespace Backend.Logics
{
    public interface IAppUserLogic
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