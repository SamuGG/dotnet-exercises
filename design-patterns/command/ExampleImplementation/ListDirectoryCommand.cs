namespace DesignPatterns.Command.ExampleImplementation;

public sealed class ListDirectoryCommand(FileSystemReceiver fileSystemReceiver) : ICommand
{
    private readonly FileSystemReceiver _fileSystemReceiver = fileSystemReceiver;

    public void Execute(string[] args)
    {
        string path = args.Length == 0 ? "." : args[0];
        _fileSystemReceiver.ListFiles(path);
    }
}