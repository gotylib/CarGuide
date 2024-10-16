using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<EntityCar>> GetAllAsync();
        Task<EntityCar> GetByIdAsync(int id);
        Task<bool> AddAsync(Car car);
        Task<bool> UpdateAsync(Car car);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateQuantityAsync(int id, int quantity);
        Task<bool> SetAvailabilityAsync(int id, bool isAvailable);
    }
}
