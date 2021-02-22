using System;

namespace drinksApp.Drinks.Implementations
{
    public class Coke : IDrink
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public string DrinkName => nameof(Coke);
        public bool LoadClassFromAssembly => true;

        public Coke(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public void Serve()
        {
            _outputProvider("Do you want lemmon?");

            if (_inputProvider().Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                _outputProvider($"There you go! A nice {DrinkName} with lemmon.");
                return;
            }

            _outputProvider($"That's ok. Just a cold {DrinkName} then.");
        }
    }
}