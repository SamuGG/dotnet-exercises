namespace DesignPatterns.Interpreter.MathImplementation;

public class AddExpression(Expression left, Expression right) : Expression
{
    private readonly Expression _left = left;
    private readonly Expression _right = right;

    public override int Interpret()
    {
        return _left.Interpret() + _right.Interpret();
    }
}