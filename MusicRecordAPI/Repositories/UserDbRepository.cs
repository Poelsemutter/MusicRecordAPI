using MusicRecordAPI.Data;
using MusicRecordAPI.Models;

namespace MusicRecordAPI.Repositories
{
    public class UserDbRepository : IUserRepository
    {
        private readonly MusicRecordDbContext _context;

        public UserDbRepository(MusicRecordDbContext context)
        {
            _context = context;
        }

        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public User? ValidateUser(string username, string password)
        {
            User? user = GetByUsername(username);
            if (user == null || user.Password != password)
            {
                return null;
            }
            return user;
        }

        public void Add(User user)
        {
            if (GetByUsername(user.Username) != null)
            {
                throw new ArgumentException("Brugernavnet findes allerede");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
