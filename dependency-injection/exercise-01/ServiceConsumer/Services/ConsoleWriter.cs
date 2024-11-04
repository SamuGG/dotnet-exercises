namespace ServiceConsumer.Services;

interface IConsoleWriter
{
    void WriteLine(string message);
}

public sealed class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}