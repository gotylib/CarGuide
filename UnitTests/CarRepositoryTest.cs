using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using global::Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;



namespace Infrastructure.Tests.Repositories
{
    public class CarRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public CarRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }
        [Fact]
        public async Task AddAsync_ShouldAddCar()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var repository = new CarRepository(context);
                var car = new Car("Toyota", "Corolla", "Red", 10, true,1);


                // Act
                var result = await repository.AddAsync(car);

                // Assert
                Assert.True(result);
                Assert.Equal(1, await context.Cars.CountAsync());

            }
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteCar()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var repository = new CarRepository(context);
                var car = new Car("Toyota", "Corolla", "Red", 10, true, 3);
                await repository.AddAsync(car);
                await repository.GetByIdAsync(car.Id.Value);
                // Act
                var result = await repository.DeleteAsync(car.Id.Value);

                // Assert
                Assert.True(result);
                Assert.Equal(0, await context.Cars.CountAsync());
            }
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCars_WhenPriorityIsTrue()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var repository = new CarRepository(context);
                await repository.AddAsync(new Car("Toyota", "Corolla", "Red", 10, true,1));
                await repository.AddAsync(new Car("Honda", "Civic", "Blue", 5, false,2));

                // Act
                var result = await repository.GetAllAsync(true);

                // Assert
                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public async Task SetAvailabilityAsync_ShouldUpdateAvailability()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var repository = new CarRepository(context);
                var car = new Car("Toyota", "Corolla", "Red", 10, true, 3);
                await repository.AddAsync(car);

                // Act
                var result = await repository.SetAvailabilityAsync(car.Id.Value, false);

                // Assert
                Assert.True(result);
                var updatedCar = await context.Cars.FindAsync(car.Id);
                Assert.False(updatedCar.IsAvailable);
            }
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateCarDetails()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var repository = new CarRepository(context);
                var car = new Car("Toyota", "Corolla", "Red", 10, true, 4);
                await repository.AddAsync(car);

                var updatedCar = new Car("Toyota", "Camry", "Blue", 5, false, 5);

                // Act
                var result = await repository.UpdateAsync(car.Id.Value, updatedCar);

                // Assert
                Assert.True(result);
                var retrievedCar = await context.Cars.FindAsync(car.Id);
                Assert.Equal("Camry", retrievedCar.Model);
                Assert.Equal("Blue", retrievedCar.Color);
            }
        }

        [Fact]
        public async Task UpdateQuantityAsync_ShouldUpdateStockCount()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var repository = new CarRepository(context);
                var car = new Car("Toyota", "Corolla", "Red", 10, true, 6);
                await repository.AddAsync(car);

                // Act
                var result = await repository.UpdateQuantityAsync(car.Id.Value, 15);

                // Assert
                Assert.True(result);
                var updatedCar = await context.Cars.FindAsync(car.Id.Value);
                Assert.Equal(15, updatedCar.StockCount);
            }
        }
    }
}

