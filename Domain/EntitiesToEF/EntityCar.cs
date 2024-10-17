using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EntityCar
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int StockCount { get; set; }
        public bool IsAvailable { get; set; }

        public static EntityCar ConwertToEntityCar(Car car)
        {
            EntityCar entityCar = new EntityCar();
            entityCar.Make = car.Make;
            entityCar.Model = car.Model;
            entityCar.Color = car.Color;
            entityCar.StockCount = car.StockCount;
            entityCar.IsAvailable = car.IsAvailable;
            if(car.Id != null)
            {
                entityCar.Id = car.Id.Value;
            }
            return entityCar;
        }

        public static Car ConvertToCar(EntityCar entityCar)
        {
            Car car = new Car(entityCar.Make, entityCar.Model, entityCar.Color, entityCar.StockCount, entityCar.IsAvailable, entityCar.Id);
            return car;
        }

    }
}
