using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class UserConnectionRepository : IUserConnectionRepository
    {
        private readonly AppDbContext _context;

        public UserConnectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserConnection> Read(string userid)
        {
            var conn = await _context.UserConnections.FirstOrDefaultAsync(x => x.UserId == userid);
            return conn;
        }
    }
}
