using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormTagHelpers.Models
{
    public interface IRepository
    {
        IEnumerable<Fruit> Fruits { get; }
        void AddFruit(Fruit fruit);
    }

    public class FruitRepo : IRepository
    {
        private List<Fruit> fruits = new List<Fruit>
        {
            new Fruit {Name="Bananas", Price = 1.20m, Qty = 5 },
            new Fruit {Name="Apples", Price = 1.80m, Qty = 3 },
            new Fruit {Name="Oranges", Price = 1.10m, Qty = 4 }
        };

        public IEnumerable<Fruit> Fruits => fruits;

        public void AddFruit(Fruit fruit)
        {
            fruits.Add(fruit);
        }
    }
}
