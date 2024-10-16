
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> AddAsync(User user)
        {
            await _userManager.CreateAsync(user, user.Password);
            return true;
        }

        public async Task<bool> DeleteAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user!=null)
            {
                await _userManager.DeleteAsync(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User?> GetByNameAsync(string name)
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

        public async Task<bool> UpdateAsync(User user)
        {
            var Olduser = await _userManager.FindByNameAsync(user.UserName);
            if (Olduser != null)
            {
                await _userManager.UpdateAsync(user);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
