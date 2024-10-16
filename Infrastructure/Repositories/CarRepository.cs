using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> AddAsync(Car car)
        {

            await _context.Cars.AddAsync(EntityCar.ConwertToEntityCar(car));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var car = await GetByIdAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<EntityCar>> GetAllAsync(bool priority)
        {
            if (priority)
            {
                return await _context.Cars.ToListAsync();
            }
            else
            {
                return await _context.Cars.Where(c => c.IsAvailable == true).ToListAsync();
            }
        }

        public async Task<EntityCar?> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<bool> SetAvailabilityAsync(int id, bool isAvailable)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                car.IsAvailable = isAvailable;
                _context.Cars.Update(car);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, Car car)
        {
            var updateCar = _context.Cars.Find(id);
            if (updateCar != null) 
            {
                updateCar.Make = car.Make;
                updateCar.Color = car.Color;
                updateCar.Model = car.Model;
                updateCar.IsAvailable = car.IsAvailable;
                updateCar.StockCount = car.StockCount;
                _context.Cars.Update(updateCar);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;   
            }
        }
        public async Task<bool> UpdateQuantityAsync(int id, int quantity)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                car.StockCount = quantity;
                _context.Cars.Update(car);  
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
