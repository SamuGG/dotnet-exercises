namespace DesignPatterns.TemplateMethod.ExampleImplementation;

public abstract class FileParser
{
    public IDictionary<string, string> ParseFile(string path)
    {
        LogOperation($"Validating file '{path}'");
        ValidateFile(path);

        LogOperation("Loading file");
        string content = File.ReadAllText(path);

        LogOperation("Parsing the file");
        IDictionary<string, string> data = ParseContent(content);

        LogOperation("Enriching data");
        EnrichData(data);

        LogOperation("Validating data");
        ValidateData(data);

        return data;
    }

    private static void ValidateFile(string path)
    {
        var fileInfo = new FileInfo(path) ?? throw new FileNotFoundException("File not found", path);

        if (fileInfo.Length == 0)
            throw new InvalidOperationException($"The file is empty: '{path}'");
    }

    public abstract IDictionary<string, string> ParseContent(string content);

    protected virtual void EnrichData(IDictionary<string, string> data)
    {
        data["ParsedAt"] = DateTime.Now.ToString("u");
    }

    protected virtual void ValidateData(IDictionary<string, string> data)
    { }

    public virtual void LogOperation(string message)
    {
        Console.WriteLine($"[{DateTime.Now:u}] {message}");
    }
}