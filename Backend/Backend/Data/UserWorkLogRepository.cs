using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class UserWorkLogRepository : IUserWorkLogRepository
    {
        private readonly AppDbContext _context;

        public UserWorkLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserWorkLog> CreateAsync(CreateUserWorkLogDto createDto)
        {
            var uwl = new UserWorkLog()
            {
                AppUserId = createDto.AppUserId,
                TaskItemId = createDto.TaskItemId,
                LogDate = DateTime.UtcNow,
                WorkTime = TimeSpan.FromMinutes(createDto.WorkTimeInMins).Ticks,
            };

            var old = await _context.UserWorkLogs.FirstOrDefaultAsync(x => x.Id == uwl.Id);
            if (old != null) throw new ArgumentException("There's already a UWL with this id: " + uwl.Id);

            _context.Add(uwl);
            await _context.SaveChangesAsync();

            var item = await ReadAsync(uwl.Id);

            return item;


            /*
            var old = await _context.UserWorkLogs.FirstOrDefaultAsync(t => t.AppUserId == createDto.AppUserId && t.TaskItemId == createDto.TaskItemId);
            if (old != null)
            {
                var oldTicks = old.WorkTime;
                var newWorkTime = TimeSpan.FromMinutes(createDto.WorkTimeInMins);
                var newTicks = oldTicks + newWorkTime.Ticks;
                old.WorkTime = newTicks;
            }
            else
            {
                UserWorkLog uwl = new UserWorkLog()
                {
                    AppUserId = createDto.AppUserId,
                    TaskItemId = createDto.TaskItemId,
                    WorkTime = TimeSpan.FromMinutes(createDto.WorkTimeInMins).Ticks
                };
                _context.UserWorkLogs.Add(uwl);
            }
            await _context.SaveChangesAsync();
            
            var item = await ReadAsync(createDto.AppUserId, createDto.TaskItemId);
            
            return item;
            */
        }

        public async Task<IEnumerable<UserWorkLog>> GetUsersWorkLogsAsync(string userid)
        {
            var allWorklogs = await ReadAsync();
            var uwls = allWorklogs.Where(x => x.AppUserId == userid).ToList();
            return uwls;
        }

        public async Task<IEnumerable<UserWorkLog>> ReadAsync()
        {
            var uwls = await _context.UserWorkLogs
                .Include(x => x.AppUser)
                .Include(x => x.TaskItem)
                .ToListAsync();
            return uwls;
        }

        public async Task<UserWorkLog> ReadAsync(string id)
        {
            var userWorkLog = await _context.UserWorkLogs
                .Include(x => x.AppUser)
                .Include(x => x.TaskItem)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (userWorkLog == null)
            {
                throw new ArgumentException("There's no UserWorkLog with this Id: " + id);
            }
            return userWorkLog;
        }

        public async Task<UserWorkLog> ReadAsync(string appUserId, string taskItemId)
        {
            var userWorkLog = await  _context.UserWorkLogs
                .Include(x => x.AppUser)
                .Include(x => x.TaskItem)
                .FirstOrDefaultAsync(t => t.AppUserId == appUserId && t.TaskItemId == taskItemId);
            if (userWorkLog == null)
            {
                throw new ArgumentException("There's no UserWorkLog with this UserId: " + appUserId + " and with this TaskItemId: " + taskItemId);
            }
            return userWorkLog;
        }

        public void Delete(string appUserId, string taskItemId)
        {
            var userWorkLog = _context.UserWorkLogs.FirstOrDefault(t => t.AppUserId == appUserId && t.TaskItemId == taskItemId);
            if (userWorkLog == null)
            {
                throw new ArgumentException("There's no UserWorkLog with this UserId: " + appUserId + " and with this TaskItemId: " + taskItemId);
            }

            _context.UserWorkLogs.Remove(userWorkLog);
            _context.SaveChanges();
        }

        public void Update(UserWorkLog userWorkLog)
        {
            var old = _context.UserWorkLogs.FirstOrDefault(t => t.AppUserId == userWorkLog.AppUserId && t.TaskItemId == userWorkLog.TaskItemId);
            if (old == null)
            {
                throw new ArgumentException("There's no UserWorkLog with this UserId: " + userWorkLog.AppUserId + " and with this TaskItemId: " + userWorkLog.TaskItemId);
            }
            old.WorkTime = userWorkLog.WorkTime;

            _context.SaveChanges();
        }
    }
}
