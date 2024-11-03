using Game.Catalog.Contracts.Events;
using Game.Catalog.Domain.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Catalog.Application.CatalogItems.EventHandlers;

internal class CatalogItemDeletedEventHandler : INotificationHandler<CatalogItemDeletedEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public CatalogItemDeletedEventHandler(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(CatalogItemDeletedEvent notification, CancellationToken cancellationToken)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        IPublishEndpoint publisher = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

        await publisher.Publish<ICatalogItemDeletedEvent>(new
        {
            notification.Item.Id
        },
        cancellationToken);
    }
}