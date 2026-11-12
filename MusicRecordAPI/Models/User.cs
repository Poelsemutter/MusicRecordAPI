using System.Security.Claims;

namespace MusicRecordAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Role { get; set; } = "User";

        public User() {}
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
