using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DependencyInjectionPattern
{
    public class DrinkWithBeer
    {
        private Beer _beer;
        private decimal _water;
        private decimal _sugar;

        public DrinkWithBeer(decimal water, decimal sugar, Beer beer)
        {
            _water = water;
            _sugar = sugar;
            _beer = beer;
        }
        public void Build()
        {
            Console.WriteLine($"We prepare drink that contains water {_water} " +
                 $" sugar {_sugar} and beer {_beer.Name}");
        }
    }
}
