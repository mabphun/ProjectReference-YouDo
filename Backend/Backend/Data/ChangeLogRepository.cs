using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ChangeLogRepository : IChangeLogRepository
    {
        private readonly AppDbContext _context;

        public ChangeLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ChangeLog changeLog)
        {
            var old = _context.ChangeLogs.FirstOrDefault(t => t.Id == changeLog.Id);
            if (old != null)
            {
                throw new ArgumentException("There's already a ChangeLog with this id: " + changeLog.Id);
            }

            _context.ChangeLogs.Add(changeLog);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChangeLog>> ReadAsync()
        {
            return await _context.ChangeLogs.Include(x => x.TaskItem).ToListAsync();
        }

        public async Task<ChangeLog> ReadAsync(string id)
        {
            var changeLog = await _context.ChangeLogs
                //.Include(x => x.TaskList)
                //.Include(x=> x.TaskList.AssignedMembers)
                .Include(x => x.TaskItem)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (changeLog == null) throw new ArgumentException("There's no ChangeLog with this id: " + id);

            return changeLog;
        }

        public async Task DeleteAsync(string id)
        {
            var changeLog = await _context.ChangeLogs.FirstOrDefaultAsync(t => t.Id == id);
            if (changeLog == null) throw new ArgumentException("There's no ChangeLog with this id: " + id);

            _context.ChangeLogs.Remove(changeLog);
            await _context.SaveChangesAsync();
        }
    }
}
