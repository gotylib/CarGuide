using DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User 
    {
        public string Name {  get; private set; }
        public string Email { get; private set; }
        public string? Role { get; private set; }
        public string? Password { get; private set; }
        public string? RefreshToken { get; private set; }

        public DateTime? RefreshTokenExpiration { get; private set; }

        public User(string _Name, string _Email,string _Password = null, string Role = null, string _RefreshToke = null) 
        {
            Name = _Name;
            Email = _Email;
            Password = _Password;
            RefreshToken = _RefreshToke;
        }
        public User (UserDto _user)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "RegisterDto cannot be null.");
            }
            Name = _user.Username;
            Email = _user.Email;
            Password = _user.Password;
            
        }

    }
    
}
