using System;
using drinksApp.Drinks;

namespace drinksApp
{
    public class Bartender
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private readonly DrinkFactory _drinkFactory;

        public Bartender(Func<string> inputProvider, Action<string> outputProvider, DrinkFactory drinkFactory)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
            _drinkFactory = drinkFactory;
        }

        public void AskForDrink()
        {
            _outputProvider($"What drink do you want ({string.Join(", ", _drinkFactory.GetAvailableDrinks())})?");

            IDrink drink = _drinkFactory.GetDrink(_inputProvider());
            drink.Serve();
        }
    }
}
