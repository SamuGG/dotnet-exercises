namespace DesignPatterns.Builder.DirectorImplementation.Builders;

public interface IBuilder
{
    void BuildName();
    void BuildDescription();
    Product Build();
}