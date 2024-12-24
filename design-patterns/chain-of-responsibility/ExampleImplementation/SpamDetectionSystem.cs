namespace DesignPatterns.ChainOfResponsibility.ExampleImplementation;

public sealed class SpamDetectionSystem
{
    private readonly SpamHandler _chain;

    public SpamDetectionSystem()
    {
        _chain = new KeywordHandler();
        BlacklistHandler blacklistHandler = new();
        MachineLearningHandler mlHandler = new();
        _chain.SetSuccessor(blacklistHandler);
        blacklistHandler.SetSuccessor(mlHandler);
    }

    public bool IsSpam(Email email)
    {
        return _chain.Handle(email);
    }
}