using System;

namespace JWTOnNetCore.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEmailValidate { get; set; }
        public DateTime JoinAt { get; set; }
        public DateTime LastLogin { get; set; }
        public string[] Roles { get; set; }
        public string Token { get; set; }

        public User WithoutPassword()
        {
            var copy = this;
            copy.Password = null;
            return copy;
        }
    }
}