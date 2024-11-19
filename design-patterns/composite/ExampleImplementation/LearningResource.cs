namespace DesignPatterns.Composite.ExampleImplementation;

public abstract class LearningResource
{
    public abstract string GetName();
    public abstract TimeSpan GetDuration();
    public abstract decimal GetPrice();

    public virtual void Add(LearningResource learningResource)
    { }

    public virtual void Remove(LearningResource learningResource)
    { }

    public virtual LearningResource? GetLearningResouce(string name)
    {
        return null;
    }
}