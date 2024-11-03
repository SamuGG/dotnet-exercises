using Game.Common.Domain.Entities;

namespace Game.Inventory.Domain.Entities;

public class CatalogItem : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
