
using System.Collections.ObjectModel;

namespace ServiceContainer;

public class ServiceCollection : Collection<ServiceDescriptor>
{
    public IServiceProvider BuildServiceProvider()
    {
        return new ServiceProvider(this.AsReadOnly());
    }

    public ServiceCollection AddSingleton<TService, TImplementation>()
        where TService : class
        where TImplementation : class, TService
    {
        ServiceDescriptor serviceDescriptor = CreateServiceDescriptor<TService, TImplementation>(ServiceLifetime.Singleton);
        Add(serviceDescriptor);

        return this;
    }

    public ServiceCollection AddTransient<TService, TImplementation>()
        where TService : class
        where TImplementation : class, TService
    {
        ServiceDescriptor serviceDescriptor = CreateServiceDescriptor<TService, TImplementation>(ServiceLifetime.Transient);
        Add(serviceDescriptor);

        return this;
    }

    public ServiceCollection AddSingleton<TImplementation>()
        where TImplementation : class
    {
        ServiceDescriptor serviceDescriptor = CreateServiceDescriptor<TImplementation, TImplementation>(ServiceLifetime.Singleton);
        Add(serviceDescriptor);

        return this;
    }

    public ServiceCollection AddTransient<TImplementation>()
        where TImplementation : class
    {
        ServiceDescriptor serviceDescriptor = CreateServiceDescriptor<TImplementation, TImplementation>(ServiceLifetime.Transient);
        Add(serviceDescriptor);

        return this;
    }

    public ServiceCollection AddSingleton<TImplementation>(Func<IServiceProvider, TImplementation> serviceFactory)
        where TImplementation : class
    {
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TImplementation),
            ImplementationType = typeof(TImplementation),
            ImplementationFactory = serviceFactory,
            Lifetime = ServiceLifetime.Singleton
        };
        Add(serviceDescriptor);

        return this;
    }

    public ServiceCollection AddTransient<TImplementation>(Func<IServiceProvider, TImplementation> serviceFactory)
        where TImplementation : class
    {
        var serviceDescriptor = new ServiceDescriptor
        {
            ServiceType = typeof(TImplementation),
            ImplementationType = typeof(TImplementation),
            ImplementationFactory = serviceFactory,
            Lifetime = ServiceLifetime.Transient
        };
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