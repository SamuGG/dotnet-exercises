namespace DesignPatterns.Command.ExampleImplementation;

public sealed class FileSystemReceiver
{
    public void MakeDirectory(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            Console.WriteLine("Path argument cannot be empty");
            return;
        }

        Console.WriteLine($"FileSystem created directory '{path}'");
    }

    public void SetCurrentDirectory(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            Console.WriteLine("Path argument cannot be empty");
            return;
        }

        Console.WriteLine($"FileSystem set current directory to '{path}'");
    }

    public void ListFiles(string path)
    {
        Console.WriteLine($"FileSystem listed files from '{path}'");
    }
}