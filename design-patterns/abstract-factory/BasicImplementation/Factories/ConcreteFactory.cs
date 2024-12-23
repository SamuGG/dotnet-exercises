using DesignPatterns.AbstractFactory.BasicImplementation.Products;

namespace DesignPatterns.AbstractFactory.BasicImplementation.Factories;

public class ConcreteFactory : AbstractFactory
{
    public override Product1 CreateProduct1()
    {
        return new ConcreteProduct1();
    }

    public override Product2 CreateProduct2()
    {
        return new ConcreteProduct2();
    }
}