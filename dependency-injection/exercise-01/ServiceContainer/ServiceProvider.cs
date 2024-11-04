using System.Reflection;

namespace ServiceContainer;

public class ServiceProvider : IServiceProvider
{
    private static readonly Dictionary<Type, Func<object?>> _transientTypes = new();
    private static readonly Dictionary<Type, Lazy<object?>> _singletonTypes = new();

    internal ServiceProvider(IReadOnlyCollection<ServiceDescriptor> descriptors)
    {
        GenerateServices(descriptors);
    }

    public object? GetService(Type serviceType)
    {
        Lazy<object?>? singletonServiceFactory = _singletonTypes.GetValueOrDefault(serviceType);

        if (singletonServiceFactory is { })
            return singletonServiceFactory.Value;

        Func<object?>? transientServiceFactory = _transientTypes.GetValueOrDefault(serviceType);
        return transientServiceFactory?.Invoke();
    }

    private void GenerateServices(IReadOnlyCollection<ServiceDescriptor> descriptors)
    {
        foreach (ServiceDescriptor descriptor in descriptors)
        {
            switch (descriptor.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    _singletonTypes[descriptor.ServiceType] = new Lazy<object?>(() =>
                        Activator.CreateInstance(descriptor.ImplementationType, GetConstructorParameters(descriptor.ImplementationType)));

                    continue;

                case ServiceLifetime.Transient:
                    _transientTypes[descriptor.ServiceType] = () =>
                        Activator.CreateInstance(descriptor.ImplementationType, GetConstructorParameters(descriptor.ImplementationType));

                    continue;

                default:
                    throw new InvalidOperationException($"Invalid service lifetime '{descriptor.Lifetime}'");
            }
        }
    }

    private object?[] GetConstructorParameters(Type implementationType)
    {
        ConstructorInfo constructor = implementationType.GetConstructors().First();
        object?[] parameters = constructor
            .GetParameters()
            .Select(parameter => GetService(parameter.ParameterType))
            .ToArray();

        return parameters;
    }
}
