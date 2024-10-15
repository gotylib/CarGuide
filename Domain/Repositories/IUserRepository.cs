using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByNameAsync(string name);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(string name);
    }
}
