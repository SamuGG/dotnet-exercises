using DesignPatterns.Factory.BasicImplementation.Products;

namespace DesignPatterns.Factory.BasicImplementation.Creators;

public abstract class Creator
{
    public abstract Product CreateProduct();
}