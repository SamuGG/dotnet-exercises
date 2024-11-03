using Game.Catalog.Application.Common.Interfaces;
using Game.Catalog.Domain.Entities;
using Game.Catalog.Infrastructure.Persistence;
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

namespace Game.Catalog.Infrastructure.DependencyInjection;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMongoDatabase(configuration);
        services.AddApplicationDbContext(configuration["CollectionName"]);
        services.AddMassTransit(new Uri(configuration.GetConnectionString("rabbitmq")));
        services.AddSingleton<IDateTimeService, DateTimeService>();

        return services;
    }

    private static IServiceCollection AddMongoDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        services.AddSingleton(serviceProvider =>
            new MongoClient(configuration.GetConnectionString("mongodb"))
                .GetDatabase(configuration["ServiceName"]));

        return services;
    }

    private static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string collectionName)
    {
        services.AddSingleton<IEntityTracker<CatalogItem>, EntityTracker<CatalogItem>>();

        services.AddSingleton<ITrackedRepository<CatalogItem>>(serviceProvider =>
            new MongoRepository<CatalogItem>(
                serviceProvider.GetRequiredService<IMongoDatabase>(),
                collectionName,
                serviceProvider.GetRequiredService<IEntityTracker<CatalogItem>>()));

        services.AddSingleton<IApplicationDbContext>(serviceProvider =>
            new ApplicationDbContext(
                serviceProvider.GetRequiredService<IMediator>(),
                serviceProvider.GetRequiredService<ITrackedRepository<CatalogItem>>()));

        return services;
    }

    private static IServiceCollection AddMassTransit(this IServiceCollection services, Uri rabbitMqConnection)
    {
        services.AddMassTransit(bus =>
        {
            bus.UsingRabbitMq((context, rabbitMqConfig) =>
                rabbitMqConfig.Host(rabbitMqConnection));
        });
        services.AddOptions<MassTransitHostOptions>()
            .Configure(options => options.WaitUntilStarted = true);

        return services;
    }
}