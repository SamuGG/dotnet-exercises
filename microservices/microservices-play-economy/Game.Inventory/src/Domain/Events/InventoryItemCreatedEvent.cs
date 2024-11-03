using System.Diagnostics.CodeAnalysis;
using Game.Common.Domain.Events;
using Game.Inventory.Domain.Entities;

namespace Game.Inventory.Domain.Events;

public class InventoryItemCreatedEvent : BaseEvent
{
    public InventoryItem Item { get; init; }

    public InventoryItemCreatedEvent([NotNull] InventoryItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Item = item;
    }
}