using System;

namespace drinksApp.Drinks.Implementations
{
    public class Juice : IDrink
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public string DrinkName => nameof(Juice);
        public bool LoadClassFromAssembly => true;

        public Juice(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public void Serve()
        {
            _outputProvider($"There you go! A fresh {DrinkName}.");
        }
    }
}
