namespace DesignPatterns.ChainOfResponsibility.ExampleImplementation;

public sealed class MachineLearningHandler : SpamHandler
{
    public override bool Handle(Email email)
    {
        if (email.Subject.Length % 2 == 0)
        {
            Console.WriteLine("Model predicted email is spam");
            return true;
        }

        Console.WriteLine("Model predicted email is not spam");

        if (_successor is null)
            return false;

        return _successor.Handle(email);
    }
}