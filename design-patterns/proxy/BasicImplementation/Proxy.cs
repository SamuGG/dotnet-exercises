namespace DesignPatterns.Proxy.BasicImplementation;

public class Proxy : Subject
{
    private readonly Lazy<RealSubject> _subject = new(() =>
    {
        Console.WriteLine("Creating real subject");
        return new();
    });

    public Proxy()
    {
        Console.WriteLine("Instantiating proxy");
    }

    public void Operation()
    {
        Console.WriteLine("Performing operation from proxy");
        _subject.Value.Operation();
        Console.WriteLine("Performing post-operation from proxy");
    }
}