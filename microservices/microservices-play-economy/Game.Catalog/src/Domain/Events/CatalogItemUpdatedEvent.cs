using System.Diagnostics.CodeAnalysis;
using Game.Catalog.Domain.Entities;
using Game.Common.Domain.Events;

namespace Game.Catalog.Domain.Events;

public class CatalogItemUpdatedEvent : BaseEvent
{
    public CatalogItem Item { get; init; }

    public CatalogItemUpdatedEvent([NotNull] CatalogItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Item = item;
    }
}