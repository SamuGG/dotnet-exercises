using System.Diagnostics.CodeAnalysis;
using Game.Catalog.Domain.Entities;
using Game.Common.Domain.Events;

namespace Game.Catalog.Domain.Events;

public class CatalogItemDeletedEvent : BaseEvent
{
    public CatalogItem Item { get; init; }

    public CatalogItemDeletedEvent([NotNull] CatalogItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Item = item;
    }
}