using DesignPatterns.Builder.DirectorImplementation;
using DesignPatterns.Builder.DirectorImplementation.Builders;

public class ComplexProductBuilder : IBuilder
{
    private string _name = string.Empty;
    private string _description = string.Empty;

    public void BuildDescription()
    {
        _description = "This is a complex product";
    }

    public void BuildName()
    {
        _name = "Complex Product";
    }

    public Product Build()
    {
        return new Product(_name, _description);
    }
}