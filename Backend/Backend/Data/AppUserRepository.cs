using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;

        public AppUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(AppUser user)
        {
            var old = _context.Users.FirstOrDefault(t => t.Id == user.Id);
            if (old != null)
            {
                throw new ArgumentException("There's already a user with this id: " + user.Id);
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<AppUser>> GetUsersByQueryAsync(string query)
        {
            var users = await _context.Users
                .Where(x=> x.UserName.Contains(query))
                .ToListAsync();
            return users;
        }

        public async Task<IEnumerable<AppUser>> ReadAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<AppUser> ReadAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(t => t.Id == id);
            if (user == null) throw new ArgumentException("There's no user with this id: " + id);

            return user;
        }

        public void Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                throw new ArgumentException("There's no user with this id: " + id);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(AppUser user)
        {
            var old = _context.Users.FirstOrDefault(t => t.Id == user.Id);
            if (old == null)
            {
                throw new ArgumentException("There's no user with this id: " + user.Id);
            }
            old.Image = user.Image;
            old.FirstName = user.FirstName;
            old.LastName = user.LastName;

            _context.SaveChanges();
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.UserName == username);
        }

        public async Task<AppUser> GetUserByIdAsync(string userid)
        {
            var user = await _context.Users.FindAsync(userid);
            return user;
        }
    }
}
