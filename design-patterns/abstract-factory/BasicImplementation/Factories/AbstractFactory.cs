using DesignPatterns.AbstractFactory.BasicImplementation.Products;

namespace DesignPatterns.AbstractFactory.BasicImplementation.Factories;

public abstract class AbstractFactory
{
    public abstract Product1 CreateProduct1();
    public abstract Product2 CreateProduct2();
}