namespace DesignPatterns.Command.BasicImplementation;

public sealed class ConcreteCommand(Receiver receiver, string message) : Command
{
    private readonly Receiver _receiver = receiver;
    private readonly string _message = message;

    public void Execute()
    {
        _receiver.Action(_message);
    }

    public void Undo()
    {
        _receiver.UndoAction(_message);
    }
}