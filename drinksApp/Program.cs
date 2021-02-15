using System;
using drinksApp.Drinks;

namespace drinksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DrinkFactory drinkFactory = new DrinkFactory(Console.ReadLine, Console.WriteLine);
            Bartender bartender = new Bartender(Console.ReadLine, Console.WriteLine, drinkFactory);

            while (true)
            {
                bartender.AskForDrink();
            }
        }
    }
}
