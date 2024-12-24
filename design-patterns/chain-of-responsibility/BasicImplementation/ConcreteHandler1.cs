namespace DesignPatterns.ChainOfResponsibility.BasicImplementation;

public sealed class ConcreteHandler1 : Handler
{
    public override void Handle(string request)
    {
        if (request.Equals("1", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Handler 1 handled request 1");
            return;
        }

        if (_successor is null)
            return;

        _successor.Handle(request);
    }
}