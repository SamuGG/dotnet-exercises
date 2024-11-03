using Game.Catalog.Contracts.Events;
using Game.Catalog.Domain.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Catalog.Application.CatalogItems.EventHandlers;

internal class CatalogItemCreatedEventHandler : INotificationHandler<CatalogItemCreatedEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public CatalogItemCreatedEventHandler(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(CatalogItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        IPublishEndpoint publisher = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

        await publisher.Publish<ICatalogItemCreatedEvent>(new
        {
            notification.Item.Id,
            notification.Item.Name,
            notification.Item.Description
        },
        cancellationToken);
    }
}