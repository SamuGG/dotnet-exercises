namespace DesignPatterns.Interpreter.SearchQueryLanguage;

public abstract class Expression
{
    public abstract IReadOnlyCollection<string> Interpret(IReadOnlyCollection<string> words);
}