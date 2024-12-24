using DesignPatterns.Builder.DirectorImplementation;
using DesignPatterns.Builder.DirectorImplementation.Builders;

public class SimpleProductBuilder : IBuilder
{
    private string _name = string.Empty;
    private string _description = string.Empty;

    public void BuildDescription()
    {
        _description = "This is a simple product";
    }

    public void BuildName()
    {
        _name = "Simple Product";
    }

    public Product Build()
    {
        return new Product(_name, _description);
    }
}