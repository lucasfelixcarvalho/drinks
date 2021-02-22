namespace drinksApp.Drinks
{
    public interface IDrink
    {
        void Serve();

        public string DrinkName { get; }
        public bool LoadClassFromAssembly { get; }
    }
}
