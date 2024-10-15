using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string? Password { get; private set; }
        public string? RefreshToken { get; private set; }

        public DateTime? RefreshTokenExpiration { get; private set; }

        public User(string _Password, string _RefreshToke, DateTime _RefreshTokenExpiration) 
        {
            Password = _Password;
            RefreshToken = _RefreshToke;
            RefreshTokenExpiration = _RefreshTokenExpiration;
        }
    }
    
}
