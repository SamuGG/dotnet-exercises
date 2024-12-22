namespace DesignPatterns.Command.BasicImplementation;

public interface Command
{
    void Execute();
    void Undo();
}