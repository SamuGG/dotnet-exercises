using DesignPatterns.TemplateMethod.BasicImplementation;
using DesignPatterns.TemplateMethod.ExampleImplementation;

AbstractClass instance = new ConcreteClass1();
instance.TemplateMethod();

Console.WriteLine();

AbstractClass instance2 = new ConcreteClass2();
instance2.TemplateMethod();

Console.WriteLine();

var csvParser = new CsvParser();
IDictionary<string, string> csvData = csvParser.ParseFile("data/sample.csv");
PrintData(csvData);

Console.WriteLine();

var jsonParser = new JsonParser();
IDictionary<string, string> jsonData = jsonParser.ParseFile("data/sample.json");
PrintData(jsonData);

static void PrintData(IDictionary<string, string> data)
{
    foreach (KeyValuePair<string, string> pair in data)
        Console.WriteLine($"{pair.Key}: {pair.Value}");
}