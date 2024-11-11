namespace DesignPatterns.TemplateMethod.BasicImplementation;

public abstract class AbstractClass
{
    public void TemplateMethod()
    {
        Console.WriteLine("Before primitive operation 1");
        PrimitiveOperation1();

        Console.WriteLine("Before primitive operation 2");
        PrimitiveOperation2();

        Console.WriteLine("Before hook");
        Hook();
    }

    public abstract void PrimitiveOperation1();
    public abstract void PrimitiveOperation2();

    public virtual void Hook()
    {
        Console.WriteLine("Hook invoked");
    }
}