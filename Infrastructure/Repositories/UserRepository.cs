
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<EntityUser> _userManager;

        public UserRepository(UserManager<EntityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> AddAsync(User user)
        {

            return await _userManager.CreateAsync(EntityUser.ConwertToEntityUser(user), user.Password);
            
        }

        public async Task<IdentityResult> DeleteAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return await _userManager.DeleteAsync(user);

        }

        public async Task<List<EntityUser>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<EntityUser?> GetByNameAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<IdentityResult> UpdateAsync(User user)
        {
            var Olduser = await _userManager.FindByNameAsync(user.Name);

             return await _userManager.UpdateAsync(EntityUser.ConwertToEntityUser(user));

        }
    }
}
