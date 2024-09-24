using Backend.Data;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public class ChangeLogLogic : IChangeLogLogic
    {
        private readonly IChangeLogRepository _changeLogRepo;

        public ChangeLogLogic(IChangeLogRepository changeLogRepo)
        {
            _changeLogRepo = changeLogRepo;
        }

        public async Task CreateAsync(ChangeLog changeLog)
        {
            // Validations can be here
            await _changeLogRepo.CreateAsync(changeLog);
        }

        public async Task<IEnumerable<ChangeLog>> ReadAsync()
        {
            return await _changeLogRepo.ReadAsync();
        }

        public async Task<ChangeLog> ReadAsync(string id)
        {
            return await _changeLogRepo.ReadAsync(id);
        }

        public async Task DeleteAsync(string id)
        {
            await _changeLogRepo.DeleteAsync(id);
        }
    }
}
