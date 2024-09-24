using Backend.Models;

namespace Backend.Data
{
    public interface IChangeLogRepository
    {
        Task CreateAsync(ChangeLog changeLog);
        Task DeleteAsync(string id);
        Task<IEnumerable<ChangeLog>> ReadAsync();
        Task<ChangeLog> ReadAsync(string id);
    }
}