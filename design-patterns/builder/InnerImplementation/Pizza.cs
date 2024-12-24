namespace DesignPatterns.Builder.InnerImplementation;

public sealed record Pizza(PizzaBaseDough Dough, SauceTypes Sauce, CheeseTypes Cheese, IReadOnlyCollection<string> Toppings)
{
    public sealed class Builder
    {
        private PizzaBaseDough _dough = new(PizzaBaseThickness.Normal, PizzaBaseFlour.Plain);
        private SauceTypes _sauce = SauceTypes.Tomato;
        private CheeseTypes _cheese = CheeseTypes.NoCheese;
        private List<string> _toppings = [];

        public Builder WithDough(Action<PizzaBaseDough.Builder> doughBuilderAction)
        {
            var doughBuilder = new PizzaBaseDough.Builder();
            doughBuilderAction(doughBuilder);
            _dough = doughBuilder.Build();

            return this;
        }

        public Builder WithSauce(SauceTypes sauce)
        {
            _sauce = sauce;
            return this;
        }

        public Builder WithCheese(CheeseTypes cheese)
        {
            _cheese = cheese;
            return this;
        }

        public Builder AddTopping(string topping)
        {
            _toppings.Add(topping);
            return this;
        }

        public Pizza Build()
        {
            return new Pizza(_dough, _sauce, _cheese, _toppings);
        }
    }
}