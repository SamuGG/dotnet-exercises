namespace DesignPatterns.Command.BasicImplementation;

public sealed class Invoker
{
    private readonly List<Command> _commands = [];
    private readonly Stack<Command> _commandStack = new();

    public void AddCommand(Command command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (Command command in _commands)
        {
            command.Execute();
            _commandStack.Push(command);
        }

        _commands.Clear();
    }

    public void UndoLastCommand()
    {
        Command lastCommand = _commandStack.Pop();
        lastCommand.Undo();
    }
}