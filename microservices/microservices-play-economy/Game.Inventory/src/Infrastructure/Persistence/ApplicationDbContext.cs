using System.Diagnostics.CodeAnalysis;
using Game.Inventory.Application.Common.Interfaces;
using Game.Inventory.Domain.Entities;
using Game.Common.Infrastructure.Common;
using Game.Common.Application.Common.Interfaces;
using MediatR;

namespace Game.Inventory.Infrastructure.Persistence;

public class ApplicationDbContext : IApplicationDbContext
{
    private readonly IMediator _mediator;

    public ITrackedRepository<CatalogItem> CatalogItems { get; init; }
    public ITrackedRepository<InventoryItem> InventoryItems { get; init; }

    public ApplicationDbContext(
        [NotNull] IMediator mediator,
        [NotNull] ITrackedRepository<CatalogItem> catalogItemsRepository,
        [NotNull] ITrackedRepository<InventoryItem> inventoryItemsRepository)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(catalogItemsRepository);
        ArgumentNullException.ThrowIfNull(inventoryItemsRepository);

        _mediator = mediator;
        CatalogItems = catalogItemsRepository;
        InventoryItems = inventoryItemsRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _mediator.DispatchAndClearDomainEventsAsync(CatalogItems);
        await _mediator.DispatchAndClearDomainEventsAsync(InventoryItems);
    }
}