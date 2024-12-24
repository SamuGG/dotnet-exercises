namespace DesignPatterns.ChainOfResponsibility.ExampleImplementation;

public sealed class KeywordHandler : SpamHandler
{
    public override bool Handle(Email email)
    {
        if (ContainsSpamKeywords(email.Subject) || ContainsSpamKeywords(email.Body))
        {
            Console.WriteLine("Email contains spam keywords");
            return true;
        }

        Console.WriteLine("Email doesn't contain spam keywords");

        if (_successor is null)
            return false;

        return _successor.Handle(email);
    }

    private static bool ContainsSpamKeywords(string text)
    {
        return text.Contains("Nigerian Prince", StringComparison.OrdinalIgnoreCase)
            || text.Contains("Million Dollars", StringComparison.OrdinalIgnoreCase);
    }
}