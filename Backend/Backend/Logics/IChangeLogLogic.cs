using Backend.Models;

namespace Backend.Logics
{
    public interface IChangeLogLogic
    {
        Task CreateAsync(ChangeLog changeLog);
        Task DeleteAsync(string id);
        Task<IEnumerable<ChangeLog>> ReadAsync();
        Task<ChangeLog> ReadAsync(string id);
    }
}