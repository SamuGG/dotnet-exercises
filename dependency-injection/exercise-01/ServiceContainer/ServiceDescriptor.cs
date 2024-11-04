namespace ServiceContainer;

public class ServiceDescriptor
{
    public Type ServiceType { get; init; } = default!;
    public Type ImplementationType { get; init; } = default!;
    public Func<IServiceProvider, object> ImplementationFactory { get; init; } = default!;
    public ServiceLifetime Lifetime { get; init; }
}