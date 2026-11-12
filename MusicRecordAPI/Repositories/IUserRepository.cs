using MusicRecordAPI.Models;

namespace MusicRecordAPI.Repositories

{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        User? ValidateUser(string username, string password);
        void Add(User user);
    }
}
