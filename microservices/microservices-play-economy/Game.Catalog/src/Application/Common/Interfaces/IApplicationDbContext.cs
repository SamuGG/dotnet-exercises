using Game.Catalog.Domain.Entities;
using Game.Common.Application.Common.Interfaces;

namespace Game.Catalog.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    ITrackedRepository<CatalogItem> CatalogItems { get; }

    Task SaveChangesAsync();
}