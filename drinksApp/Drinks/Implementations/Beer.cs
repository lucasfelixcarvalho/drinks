using System;

namespace drinksApp.Drinks.Implementations
{
    public class Beer : IDrink
    {
        private readonly short MinimumLegalAge = 18;
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public string DrinkName => nameof(Beer);
        public bool LoadClassFromAssembly => true;

        public Beer(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public void Serve()
        {
            _outputProvider("What's you age?");
            if (!int.TryParse(_inputProvider(), out var age))
            {
                _outputProvider("I don't know what age is this...");
                return;
            }

            if (age < MinimumLegalAge)
            {
                _outputProvider("I cannot serve you that.");
                return;
            }

            _outputProvider($"There you go! A cold {DrinkName}.");
        }
    }
}
