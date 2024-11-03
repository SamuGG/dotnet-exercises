namespace Game.Catalog.Contracts.Events;

public interface ICatalogItemCreatedEvent
{
    Guid Id { get; }
    string? Name { get; }
    string? Description { get; }
}