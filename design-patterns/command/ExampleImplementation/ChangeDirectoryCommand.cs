namespace DesignPatterns.Command.ExampleImplementation;

public sealed class ChangeDirectoryCommand(FileSystemReceiver fileSystemReceiver) : ICommand
{
    private readonly FileSystemReceiver _fileSystemReceiver = fileSystemReceiver;

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: cd <path>");
            return;
        }

        _fileSystemReceiver.SetCurrentDirectory(args[0]);
    }
}