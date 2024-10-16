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

        public User(string _Password = null, string _RefreshToke = null) 
        {
            Password = _Password;
            RefreshToken = _RefreshToke;
        }

        public void UpdateRefreshToken(string ?_RefreshToken)
        {
            RefreshToken = _RefreshToken;
        }

        public void UpdateRefreshTokenExpiration(DateTime? _RefreshTokenExpiration)
        { 
            RefreshTokenExpiration = _RefreshTokenExpiration; 
        }
    }
    
}
