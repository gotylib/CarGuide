using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EntityUser : IdentityUser
    {
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiration { get; set; }

        public static EntityUser ConwertToEntityUser(User user)
        {
            EntityUser userEntity = new EntityUser();

            userEntity.Password = user.Password;
            userEntity.RefreshToken = user.RefreshToken;
            userEntity.RefreshTokenExpiration = user.RefreshTokenExpiration;
            userEntity.UserName = user.Name;
            userEntity.Email = user.Email;
            return userEntity;
        }

        public static User ConvertToUser(EntityUser userEntity)
        {
            User user = new User(userEntity.UserName, userEntity.Email, userEntity.Password, userEntity.RefreshToken);
            return user;
        }


    }
}
