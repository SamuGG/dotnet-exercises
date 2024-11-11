using System.Text.Json;

namespace DesignPatterns.TemplateMethod.ExampleImplementation;

public class JsonParser : FileParser
{
    public override IDictionary<string, string> ParseContent(string content)
    {
        return JsonSerializer.Deserialize<Dictionary<string, string>>(content) ?? [];
    }
}