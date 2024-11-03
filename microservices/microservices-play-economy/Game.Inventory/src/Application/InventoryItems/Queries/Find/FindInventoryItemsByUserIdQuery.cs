using System.Diagnostics.CodeAnalysis;
using Game.Inventory.Application.Common.Interfaces;
using Game.Inventory.Application.InventoryItems.Queries.Find;
using MediatR;

namespace Game.Inventory.Application.Queries.Find;

public record FindInventoryItemsByUserIdQuery(Guid UserId) : IRequest<IReadOnlyCollection<InventoryItemDto>>;

internal class FindInventoryItemsByUserIdQueryHandler : IRequestHandler<FindInventoryItemsByUserIdQuery, IReadOnlyCollection<InventoryItemDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public FindInventoryItemsByUserIdQueryHandler([NotNull] IApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<InventoryItemDto>> Handle(
        FindInventoryItemsByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var userInventoryItems = await _dbContext.InventoryItems
            .FindAllAsync(inventoryItem => inventoryItem.UserId == request.UserId);

        var catalogItemIds = userInventoryItems.Select(item => item.CatalogItemId);

        var catalogItems = await _dbContext.CatalogItems
            .FindAllAsync(catalogItem => catalogItemIds.Contains(catalogItem.Id));

        return userInventoryItems.Select(inventoryItem =>
        {
            var catalogItem = catalogItems
                .FirstOrDefault(catalogItem => catalogItem.Id == inventoryItem.CatalogItemId);

            return new InventoryItemDto(
                inventoryItem.CatalogItemId,
                catalogItem?.Name,
                catalogItem?.Description,
                inventoryItem.Quantity,
                inventoryItem.AcquiredDateUtc);
        })
        .ToList();
    }
}