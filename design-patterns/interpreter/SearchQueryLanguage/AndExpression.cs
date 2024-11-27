
namespace DesignPatterns.Interpreter.SearchQueryLanguage;

public class AndExpression(Expression left, Expression right) : Expression
{
    private readonly Expression _left = left;
    private readonly Expression _right = right;

    public override IReadOnlyCollection<string> Interpret(IReadOnlyCollection<string> words)
    {
        return _left.Interpret(words).Intersect(_right.Interpret(words)).ToArray();
    }
}