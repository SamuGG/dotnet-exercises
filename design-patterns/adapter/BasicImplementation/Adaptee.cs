namespace DesignPatterns.Adapter.BasicImplementation;

public sealed class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee specific request invoked");
    }
}