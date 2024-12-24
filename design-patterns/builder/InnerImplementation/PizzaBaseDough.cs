namespace DesignPatterns.Builder.InnerImplementation;

public sealed record PizzaBaseDough(PizzaBaseThickness Thickness, PizzaBaseFlour Flour)
{
    public sealed class Builder
    {
        private PizzaBaseThickness _thickness;
        private PizzaBaseFlour _flour;

        public Builder WithThickness(PizzaBaseThickness thickness)
        {
            _thickness = thickness;
            return this;
        }

        public Builder WithFlour(PizzaBaseFlour flour)
        {
            _flour = flour;
            return this;
        }

        public PizzaBaseDough Build()
        {
            return new PizzaBaseDough(_thickness, _flour);
        }
    }
}