namespace Game.Catalog.Contracts.Events;

public interface ICatalogItemDeletedEvent
{
    Guid Id { get; }
}
