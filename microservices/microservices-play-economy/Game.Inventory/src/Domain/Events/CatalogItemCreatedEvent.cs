using System.Diagnostics.CodeAnalysis;
using Game.Inventory.Domain.Entities;
using Game.Common.Domain.Events;

namespace Game.Inventory.Domain.Events;

public class CatalogItemCreatedEvent : BaseEvent
{
    public CatalogItem Item { get; init; }

    public CatalogItemCreatedEvent([NotNull] CatalogItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Item = item;
    }
}