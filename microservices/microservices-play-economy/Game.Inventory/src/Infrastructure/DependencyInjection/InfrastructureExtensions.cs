using Game.Inventory.Application.Common.Interfaces;
using Game.Inventory.Domain.Entities;
using Game.Inventory.Infrastructure.Persistence;
using Game.Common.Application.Common.Interfaces;
using Game.Common.Application.Services;
using Game.Common.Infrastructure.Persistence;
using Game.Common.Infrastructure.Services;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Game.Inventory.Application.CatalogItems.Consumers;

namespace Game.Inventory.Infrastructure.DependencyInjection;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMongoDatabase();
        services.AddApplicationDbContext(configuration["CatalogCollectionName"], configuration["InventoryCollectionName"]);
        services.AddMassTransit(new Uri(configuration.GetConnectionString("rabbitmq")));
        services.AddSingleton<IDateTimeService, DateTimeService>();
        
        return services;
    }

    private static IServiceCollection AddMongoDatabase(this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        services.AddSingleton(serviceProvider =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return new MongoClient(configuration.GetConnectionString("mongodb"))
                .GetDatabase(configuration["ServiceName"]);
        });

        return services;
    }

    private static IServiceCollection AddApplicationDbContext(
        this IServiceCollection services, 
        string catalogCollectionName, 
        string inventoryCollectionName)
    {
        services.AddSingleton<IEntityTracker<CatalogItem>, EntityTracker<CatalogItem>>();
        services.AddSingleton<IEntityTracker<InventoryItem>, EntityTracker<InventoryItem>>();
        
        services.AddSingleton<ITrackedRepository<CatalogItem>>(serviceProvider =>
            new MongoRepository<CatalogItem>(
                serviceProvider.GetRequiredService<IMongoDatabase>(), 
                catalogCollectionName, 
                serviceProvider.GetRequiredService<IEntityTracker<CatalogItem>>()));
        
        services.AddSingleton<ITrackedRepository<InventoryItem>>(serviceProvider =>
            new MongoRepository<InventoryItem>(
                serviceProvider.GetRequiredService<IMongoDatabase>(), 
                inventoryCollectionName, 
                serviceProvider.GetRequiredService<IEntityTracker<InventoryItem>>()));
        
        services.AddSingleton<IApplicationDbContext>(serviceProvider => 
            new ApplicationDbContext(
                serviceProvider.GetRequiredService<IMediator>(),
                serviceProvider.GetRequiredService<ITrackedRepository<CatalogItem>>(),
                serviceProvider.GetRequiredService<ITrackedRepository<InventoryItem>>()));

        return services;
    }

    private static IServiceCollection AddMassTransit(this IServiceCollection services, Uri rabbitMqConnection)
    {
        services.AddMassTransit(bus =>
        {
            bus.SetKebabCaseEndpointNameFormatter();
            bus.AddConsumersFromNamespaceContaining<CatalogItemCreatedConsumer>();
            bus.UsingRabbitMq((context, config) =>
            {
                config.Host(rabbitMqConnection);
                config.ConfigureEndpoints(context);
            });
        });
        services.AddOptions<MassTransitHostOptions>()
            .Configure(options => options.WaitUntilStarted = true);

        return services;
    }
}