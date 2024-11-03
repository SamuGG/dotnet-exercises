using Game.Inventory.Domain.Events;

namespace Game.Inventory.Domain.Entities.Extensions;

public static class InventoryItemExtensions
{
    public static void AddCreatedEvent(this InventoryItem inventoryItem) =>
        inventoryItem.AddDomainEvent(new InventoryItemCreatedEvent(inventoryItem));

    public static void AddUpdatedEvent(this InventoryItem inventoryItem) =>
        inventoryItem.AddDomainEvent(new InventoryItemUpdatedEvent(inventoryItem));
}