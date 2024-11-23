namespace DesignPatterns.Proxy.BasicImplementation;

public class RealSubject : Subject
{
    public RealSubject()
    {
        Console.WriteLine("Instantiating real subject");
    }

    public void Operation()
    {
        Console.WriteLine("Performing operation from real subject");
    }
}