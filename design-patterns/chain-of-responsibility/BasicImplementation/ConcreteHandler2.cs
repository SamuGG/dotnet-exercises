namespace DesignPatterns.ChainOfResponsibility.BasicImplementation;

public sealed class ConcreteHandler2 : Handler
{
    public override void Handle(string request)
    {
        if (request.Equals("2", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Handler 2 handled request 2");
            return;
        }

        if (_successor is null)
            return;

        _successor.Handle(request);
    }
}