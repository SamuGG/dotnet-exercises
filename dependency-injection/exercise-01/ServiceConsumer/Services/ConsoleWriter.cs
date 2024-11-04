namespace ServiceConsumer.Services;

interface IConsoleWriter
{
    void WriteLine(string message);
    void WriteGuid();
}

public sealed class ConsoleWriter : IConsoleWriter
{
    private readonly IGuidProvider? _guidProvider;

    public ConsoleWriter()
    {
    }

    public ConsoleWriter(IGuidProvider? guidProvider)
    {
        _guidProvider = guidProvider;
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void WriteGuid()
    {
        if (_guidProvider is null)
            return;

        Console.WriteLine(_guidProvider.Value);
    }
}