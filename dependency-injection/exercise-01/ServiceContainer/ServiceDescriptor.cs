namespace ServiceContainer;

public class ServiceDescriptor
{
    public Type ServiceType { get; init; } = default!;
    public Type ImplementationType { get; init; } = default!;
    public ServiceLifetime Lifetime { get; init; }
}