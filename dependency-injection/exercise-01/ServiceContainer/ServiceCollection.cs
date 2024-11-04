
using System.Collections.ObjectModel;

namespace ServiceContainer;

public class ServiceCollection : Collection<ServiceDescriptor>
{
    public IServiceProvider BuildServiceProvider()
    {
        return new ServiceProvider(this.AsReadOnly());
    }

    public ServiceCollection AddSingleton<TService, TImplementation>()
    {
        ServiceDescriptor serviceDescriptor = CreateServiceDescriptor<TService, TImplementation>(ServiceLifetime.Singleton);
        Add(serviceDescriptor);

        return this;
    }

    public ServiceCollection AddTransient<TService, TImplementation>()
    {
        ServiceDescriptor serviceDescriptor = CreateServiceDescriptor<TService, TImplementation>(ServiceLifetime.Transient);
        Add(serviceDescriptor);

        return this;
    }

    private static ServiceDescriptor CreateServiceDescriptor<TService, TImplementation>(ServiceLifetime lifetime)
    {
        return new ServiceDescriptor
        {
            ServiceType = typeof(TService),
            ImplementationType = typeof(TImplementation),
            Lifetime = lifetime
        };
    }
}