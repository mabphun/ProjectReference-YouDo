using Backend.Data;
using Backend.Models;

namespace Backend.Logics
{
    public class AppUserLogic : IAppUserLogic
    {
        private readonly IAppUserRepository _repo;

        public AppUserLogic(IAppUserRepository repo)
        {
            _repo = repo;
        }

        public void Create(AppUser user)
        {
            // Validations can be here
            _repo.Create(user);
        }

        public async Task<IEnumerable<AppUser>> GetUsersByQueryAsync(string query)
        {
            var users = await _repo.GetUsersByQueryAsync(query);
            return users;
        }

        public async Task<IEnumerable<AppUser>> ReadAsync()
        {
            var users = await _repo.ReadAsync();
            return users;
        }

        public async Task<AppUser> ReadAsync(string id)
        {
            var user = await _repo.ReadAsync(id);
            return user;
        }

        public void Delete(string id)
        {
            _repo.Delete(id);
        }

        public void Update(AppUser user)
        {
            _repo.Update(user);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _repo.GetUserByUsernameAsync(username);
        }

        public async Task<AppUser> GetUserByIdAsync(string userid)
        {
            return await _repo.GetUserByIdAsync(userid);
        }
    }
}
