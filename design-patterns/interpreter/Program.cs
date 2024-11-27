using DesignPatterns.Interpreter.MathImplementation;
using DesignPatterns.Interpreter.SearchQueryLanguage;

var addition = new AddExpression(
    left: new NumberExpression(1),
    right: new MultiplyExpression(
        left: new NumberExpression(2),
        right: new NumberExpression(3)
    )
);

Console.WriteLine(addition.Interpret());
Console.WriteLine();

// Language grammar:
// word | NOT word | query AND query | CONTAINS string

string[] context = ["hello", "world", "elephant", "help"];

var wordExpression = new WordExpression("hello");
PrintExpressionResult(wordExpression.Interpret(context), "Search for 'hello': ");

var notExpression = new NotExpression("hello");
PrintExpressionResult(notExpression.Interpret(context), "Search for 'NOT hello': ");

var andExpression = new AndExpression(
    left: new NotExpression("hello"),
    right: new ContainsExpression("el"));
PrintExpressionResult(andExpression.Interpret(context), "Search for 'NOT hello AND CONTAINS el': ");

static void PrintExpressionResult(IReadOnlyCollection<string> words, string title)
{
    Console.WriteLine(title);
    Console.WriteLine(string.Join(',', words));
    Console.WriteLine();
}