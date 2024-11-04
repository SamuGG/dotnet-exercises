namespace ServiceConsumer.Services;

public interface IGuidProvider
{
    Guid Value { get; }
}

public sealed class GuidProvider : IGuidProvider
{
    public Guid Value { get; } = Guid.NewGuid();
}
