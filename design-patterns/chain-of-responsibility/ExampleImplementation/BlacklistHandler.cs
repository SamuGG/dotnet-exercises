namespace DesignPatterns.ChainOfResponsibility.ExampleImplementation;

public sealed class BlacklistHandler : SpamHandler
{
    public override bool Handle(Email email)
    {
        if (IsBlacklisted(email.Sender))
        {
            Console.WriteLine("Email sender is blacklisted");
            return true;
        }

        Console.WriteLine("Email sender isn't blacklisted");

        if (_successor is null)
            return false;

        return _successor.Handle(email);
    }

    private static bool IsBlacklisted(string sender)
    {
        return sender.Contains("Spam", StringComparison.OrdinalIgnoreCase);
    }
}