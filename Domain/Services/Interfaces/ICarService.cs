using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface ICarService
    {
        // Получение всех автомобилей
        Task<IEnumerable<Car>> GetAllCarsAsync();

        // Получение автомобиля по ID
        Task<Car> GetCarByIdAsync(int id);

        // Добавление нового автомобиля
        Task AddCarAsync(Car car);

        // Обновление существующего автомобиля
        Task UpdateCarAsync(Car car);

        // Удаление автомобиля
        Task DeleteCarAsync(int id);

        // Изменение количества автомобилей
        Task UpdateCarQuantityAsync(int id, int quantity);

        // Сделать автомобиль недоступным
        Task SetCarAvailabilityAsync(int id, bool inAvailable);
    }
}
