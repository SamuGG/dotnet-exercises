namespace Game.Catalog.Contracts.Events;

public interface ICatalogItemUpdatedEvent
{
    Guid Id { get; }
    string? Name { get; }
    string? Description { get; }
}