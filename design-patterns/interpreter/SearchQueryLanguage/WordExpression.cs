
namespace DesignPatterns.Interpreter.SearchQueryLanguage;

public class WordExpression(string word) : Expression
{
    private readonly string _word = word;

    public override IReadOnlyCollection<string> Interpret(IReadOnlyCollection<string> words)
    {
        return words.Where(word => word.Equals(_word, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}