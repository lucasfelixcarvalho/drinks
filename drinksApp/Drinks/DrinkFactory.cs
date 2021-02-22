using System;
using System.Collections.Generic;
using System.Linq;
using drinksApp.Drinks.Implementations;

namespace drinksApp.Drinks
{
    public class DrinkFactory
    {
        private readonly Dictionary<string, IDrink> _drinks;
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public DrinkFactory(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;

            var drinkType = typeof(IDrink); // reference: https://www.youtube.com/watch?v=Yd4GnWeEkIY&ab_channel=NickChapsas
            _drinks = drinkType.Assembly.ExportedTypes // get all classes that references IDrink
                .Where(x => drinkType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract) // get only implementations
                .Select(x => { return Activator.CreateInstance(x, _inputProvider, _outputProvider); }) // create new instance for each implementation
                .Cast<IDrink>() // cast the object to known type IDrink
                .Where(x => x.LoadClassFromAssembly) // load only classes marked to be loaded
                .ToDictionary(x => x.DrinkName, x => x); // finally creates the dictionary
        }

        public IEnumerable<string> GetAvailableDrinks()
        {
            return _drinks.Keys.ToList();
        }

        public IDrink GetDrink(string drinkName)
        {            
            _drinks.TryGetValue(drinkName, out var drink);
            return drink ?? new UnknownDrink(_inputProvider, _outputProvider);
        }
    }
}
