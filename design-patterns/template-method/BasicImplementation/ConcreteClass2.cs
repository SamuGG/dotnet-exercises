namespace DesignPatterns.TemplateMethod.BasicImplementation;

public class ConcreteClass2 : AbstractClass
{
    public override void PrimitiveOperation1()
    {
        Console.WriteLine("Primitive operation 1 called");
    }

    public override void PrimitiveOperation2()
    {
        Console.WriteLine("Primitive operation 2 called");
    }

    public override void Hook()
    {
        Console.WriteLine($"Hook called in {nameof(ConcreteClass2)}");
    }
}