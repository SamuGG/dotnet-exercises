using Game.Common.Application.Services;
using Game.Inventory.Application.Common.Interfaces;
using Game.Inventory.Domain.Entities;
using Game.Inventory.Domain.Entities.Extensions;
using MediatR;

namespace Game.Inventory.Application.Commands.Grant;

public record GrantCatalogItemCommand(Guid UserId, Guid CatalogItemId, int Quantity) : IRequest;

internal class GrantCatalogItemCommandHandler : IRequestHandler<GrantCatalogItemCommand>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IDateTimeService _dateTimeService;

    public GrantCatalogItemCommandHandler(IApplicationDbContext dbContext, IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(dateTimeService);

        _dbContext = dbContext;
        _dateTimeService = dateTimeService;
    }

    public async Task<Unit> Handle(GrantCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var inventoryItem = await _dbContext.InventoryItems.FindOneAsync(inventoryItem =>
            inventoryItem.UserId == request.UserId
            && inventoryItem.CatalogItemId == request.CatalogItemId);

        if (inventoryItem is null)
            await GrantNewCatalogItem(request);
        else
            await UpdateUserInventory(inventoryItem, request);

        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }

    private async Task GrantNewCatalogItem(GrantCatalogItemCommand request)
    {
        var newInventoryItem = new InventoryItem
        {
            UserId = request.UserId,
            CatalogItemId = request.CatalogItemId,
            Quantity = request.Quantity,
            AcquiredDateUtc = _dateTimeService.UtcNow
        };

        await _dbContext.InventoryItems.AddNewAsync(newInventoryItem);
        newInventoryItem.AddCreatedEvent();
    }

    private async Task UpdateUserInventory(InventoryItem inventoryItem, GrantCatalogItemCommand request)
    {
        inventoryItem.Quantity = request.Quantity;
        inventoryItem = await _dbContext.InventoryItems.FindOneAndReplaceAsync(inventoryItem);
        inventoryItem.AddUpdatedEvent();
    }
}