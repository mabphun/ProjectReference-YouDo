using Backend.Data;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public class UserWorkLogLogic : IUserWorkLogLogic
    {
        private readonly IUserWorkLogRepository _userWorkLogRepo;

        public UserWorkLogLogic(IUserWorkLogRepository repo)
        {
            _userWorkLogRepo = repo;
        }

        public async Task<UserWorkLog> CreateAsync(CreateUserWorkLogDto createDto)
        {
            var uwl = await _userWorkLogRepo.CreateAsync(createDto);
            return uwl;
        }
        public async Task<IEnumerable<UserWorkLog>> GetUsersWorkLogsAsync(string userid)
        {
            var uwls = await _userWorkLogRepo.GetUsersWorkLogsAsync(userid);
            return uwls;
        }

        public async Task<IEnumerable<UserWorkLog>> ReadAsync()
        {
            var uwls = await _userWorkLogRepo.ReadAsync();
            return uwls;
        }

        public async Task<UserWorkLog> ReadAsync(string appUserId, string taskItemId)
        {
            var uwl = await _userWorkLogRepo.ReadAsync(appUserId, taskItemId);
            return uwl;
        }

        public void Delete(string appUserId, string taskItemId)
        {
            _userWorkLogRepo.Delete(appUserId, taskItemId);
        }

        public void Update(UserWorkLog userWorkLog)
        {
            _userWorkLogRepo.Update(userWorkLog);
        }

        public async Task<double> GetTotalWorkTimeAsync(string userid)
        {
            var uwls = await _userWorkLogRepo.ReadAsync();
            
            var result = 0.0;
            foreach (var item in uwls.Where(x=> x.AppUserId == userid).ToList())
            {
                var minutes = TimeSpan.FromTicks(item.WorkTime).TotalMinutes;
                double hours = minutes / 60;
                result += Math.Round(hours, 1);
            }

            return result;
        }
    }
}
