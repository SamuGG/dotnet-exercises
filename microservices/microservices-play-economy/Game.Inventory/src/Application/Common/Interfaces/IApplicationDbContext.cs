using Game.Inventory.Domain.Entities;
using Game.Common.Application.Common.Interfaces;

namespace Game.Inventory.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    ITrackedRepository<CatalogItem> CatalogItems { get; }
    ITrackedRepository<InventoryItem> InventoryItems { get; }

    Task SaveChangesAsync();
}