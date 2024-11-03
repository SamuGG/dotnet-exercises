namespace Game.Inventory.Application.InventoryItems.Queries.Find;

public record InventoryItemDto(Guid CatalogItemId, string? Name, string? Description, int Quantity, DateTimeOffset AcquiredDateUtc);