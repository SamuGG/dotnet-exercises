using DesignPatterns.Builder.InnerImplementation;

namespace DesignPatterns.Builder.StepImplementation;

public sealed record StepPizza(PizzaBaseDough Dough, SauceTypes Sauce, CheeseTypes Cheese, IReadOnlyCollection<string> Toppings)
{
    public sealed class Builder : IDoughStep, ISauceStep, ICheeseStep, IToppingStep
    {
        private PizzaBaseDough _dough = new(PizzaBaseThickness.Normal, PizzaBaseFlour.Plain);
        private SauceTypes _sauce = SauceTypes.Tomato;
        private CheeseTypes _cheese = CheeseTypes.NoCheese;
        private List<string> _toppings = [];

        private Builder()
        { }

        public static IDoughStep Begin() => new Builder();

        public ISauceStep WithDough(Action<PizzaBaseDough.Builder> builder)
        {
            var doughBuilder = new PizzaBaseDough.Builder();
            builder(doughBuilder);
            _dough = doughBuilder.Build();

            return this;
        }

        public ICheeseStep WithSauce(SauceTypes sauce)
        {
            _sauce = sauce;
            return this;
        }

        public IToppingStep WithCheese(CheeseTypes cheese)
        {
            _cheese = cheese;
            return this;
        }

        public IToppingStep AddTopping(string topping)
        {
            _toppings.Add(topping);
            return this;
        }

        public StepPizza Build()
        {
            return new StepPizza(_dough, _sauce, _cheese, _toppings);
        }
    }

    public interface IDoughStep
    {
        ISauceStep WithDough(Action<PizzaBaseDough.Builder> doughBuilderAction);
    }

    public interface ISauceStep
    {
        ICheeseStep WithSauce(SauceTypes sauce);
    }

    public interface ICheeseStep
    {
        IToppingStep WithCheese(CheeseTypes cheese);
    }

    public interface IToppingStep
    {
        IToppingStep AddTopping(string topping);
        StepPizza Build();
    }
}