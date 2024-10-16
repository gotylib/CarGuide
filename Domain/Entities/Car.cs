using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
    public class Car 
    {
        public int Id { get; private set; }    
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int StockCount { get; private set; }
        public bool IsAvailable { get; private set; }

        public Car(int _Id,string _Make, string _Model, string _Color, int _StockCount, bool _IsAvailable)
        {
            Id = _Id;
            Make = _Make;
            Model = _Model;
            Color = _Color;
            StockCount = _StockCount;
            IsAvailable = _IsAvailable;
        }
    }
}
