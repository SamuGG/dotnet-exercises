namespace DesignPatterns.TemplateMethod.BasicImplementation;

public class ConcreteClass1 : AbstractClass
{
    public override void PrimitiveOperation1()
    {
        Console.WriteLine("Primitive operation 1 invoked");
    }

    public override void PrimitiveOperation2()
    {
        Console.WriteLine("Primitive operation 2 invoked");
    }
}