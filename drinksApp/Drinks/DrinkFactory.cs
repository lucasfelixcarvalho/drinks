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

            _drinks = new Dictionary<string, IDrink>(StringComparer.OrdinalIgnoreCase)
            {
                { nameof(Beer), new Beer(_inputProvider, _outputProvider) },
                { nameof(Juice), new Juice(_inputProvider, _outputProvider) }
            };
        }

        public IEnumerable<string> GetAvailableDrinks()
        {
            return _drinks.Keys.ToList();
        }

        public IDrink GetDrink(string drinkName)
        {            
            _drinks.TryGetValue(drinkName, out var drinkAction);
            return drinkAction ?? new UnknownDrink(_inputProvider, _outputProvider);
        }
    }
}
