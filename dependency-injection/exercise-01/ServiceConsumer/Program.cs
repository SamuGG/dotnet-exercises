using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IConsoleWriter, ConsoleWriter>();
var serviceProvider = services.BuildServiceProvider();
var service = serviceProvider.GetRequiredService<IConsoleWriter>();
service.WriteLine("Hello");

interface IConsoleWriter
{
    void WriteLine(string message);
}

sealed class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}