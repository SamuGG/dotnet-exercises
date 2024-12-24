using DesignPatterns.Builder.DirectorImplementation.Builders;

namespace DesignPatterns.Builder.DirectorImplementation;

public sealed class ProductDirector(IBuilder builder)
{
    private readonly IBuilder _builder = builder;

    public void ConstructProduct()
    {
        _builder.BuildName();
        _builder.BuildDescription();
    }
}