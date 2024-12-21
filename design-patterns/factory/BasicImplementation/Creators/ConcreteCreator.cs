using DesignPatterns.Factory.BasicImplementation.Products;

namespace DesignPatterns.Factory.BasicImplementation.Creators;

public class ConcreteCreator : Creator
{
    public override Product CreateProduct()
    {
        return new ConcreteProduct();
    }
}