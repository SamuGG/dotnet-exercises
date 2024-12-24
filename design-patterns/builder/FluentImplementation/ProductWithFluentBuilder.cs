namespace DesignPatterns.Builder.FluentImplementation;

public sealed record ProductWithFluentBuilder(string Name, string Description)
{
    public sealed class Builder
    {
        private string _name = string.Empty;
        private string _description = string.Empty;

        public Builder WithName(string name)
        {
            _name = name;
            return this;
        }

        public Builder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ProductWithFluentBuilder Build()
        {
            return new ProductWithFluentBuilder(_name, _description);
        }
    }
}