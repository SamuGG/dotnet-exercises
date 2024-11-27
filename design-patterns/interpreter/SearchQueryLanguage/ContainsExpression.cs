
namespace DesignPatterns.Interpreter.SearchQueryLanguage;

public class ContainsExpression(string value) : Expression
{
    private readonly string _value = value;

    public override IReadOnlyCollection<string> Interpret(IReadOnlyCollection<string> words)
    {
        return words.Where(word => word.Contains(_value, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}