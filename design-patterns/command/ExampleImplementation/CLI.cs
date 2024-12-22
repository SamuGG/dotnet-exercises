namespace DesignPatterns.Command.ExampleImplementation;

public sealed class CLI
{
    private readonly Dictionary<string, ICommand> _commands = [];

    public void RegisterCommand(string commandName, ICommand command)
    {
        _commands[commandName] = command;
    }

    public void ExecuteCommand(string commandName, string[] commandArgs)
    {
        if (!_commands.TryGetValue(commandName, out ICommand? command))
        {
            Console.WriteLine($"Unknown command '{commandName}'");
            return;
        }

        command.Execute(commandArgs);
    }
}