namespace DesignPatterns.TemplateMethod.ExampleImplementation;

public class CsvParser : FileParser
{
    public override IDictionary<string, string> ParseContent(string content)
    {
        return content
            .Split(Environment.NewLine)
            .Aggregate<string, Dictionary<string, string>>([], (data, row) =>
            {
                string[] parts = row.Split(',', 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if (parts is null || parts.Length < 2)
                    return data;

                data[parts[0]] = parts[1];
                return data;
            });
    }

    protected override void EnrichData(IDictionary<string, string> data)
    {
        base.EnrichData(data);
        data["DataType"] = "CSV";
    }
}