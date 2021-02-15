using System;

namespace drinksApp.Drinks.Implementations
{
    public class UnknownDrink : IDrink
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public UnknownDrink(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public void Serve()
        {
            _outputProvider("I don't know what drink is this.");
        }
    }
}
