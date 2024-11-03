using Game.Catalog.Domain.Events;

namespace Game.Catalog.Domain.Entities.Extensions;

public static class CatalogItemExtensions
{
    public static void AddCreatedEvent(this CatalogItem catalogItem) =>
        catalogItem.AddDomainEvent(new CatalogItemCreatedEvent(catalogItem));

    public static void AddUpdatedEvent(this CatalogItem catalogItem) =>
        catalogItem.AddDomainEvent(new CatalogItemUpdatedEvent(catalogItem));

    public static void AddDeletedEvent(this CatalogItem catalogItem) =>
        catalogItem.AddDomainEvent(new CatalogItemDeletedEvent(catalogItem));
}