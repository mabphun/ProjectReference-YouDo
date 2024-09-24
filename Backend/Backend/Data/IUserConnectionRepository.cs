using Backend.Models;

namespace Backend.Data
{
    public interface IUserConnectionRepository
    {
        Task<UserConnection> Read(string userid);
    }
}