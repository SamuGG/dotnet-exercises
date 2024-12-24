namespace DesignPatterns.Builder.NestedImplementation;

public sealed record ProductWithBuilder(string Name, string Description)
{
    public sealed class Builder
    {
        private string _name = string.Empty;
        private string _description = string.Empty;

        public void BuildName(string name)
        {
            _name = name;
        }

        public void BuildDescription(string description)
        {
            _description = description;
        }

        public ProductWithBuilder Build()
        {
            return new ProductWithBuilder(_name, _description);
        }
    }
}