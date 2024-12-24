namespace DesignPatterns.ChainOfResponsibility.BasicImplementation;

public sealed class ConcreteHandler3 : Handler
{
    public override void Handle(string request)
    {
        if (request.Equals("3", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Handler 3 handled request 3");
            return;
        }

        if (_successor is null)
            return;

        _successor.Handle(request);
    }
}