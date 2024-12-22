namespace DesignPatterns.Command.ExampleImplementation;

public sealed class MakeDirectoryCommand(FileSystemReceiver fileSystemReceiver) : ICommand
{
    private readonly FileSystemReceiver _fileSystemReceiver = fileSystemReceiver;

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: mkdir <path>");
            return;
        }

        _fileSystemReceiver.MakeDirectory(args[0]);
    }
}