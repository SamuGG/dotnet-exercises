using Game.Common.Domain.Entities;
using Game.Inventory.Domain.Exceptions;

namespace Game.Inventory.Domain.Entities;

public class InventoryItem : BaseEntity
{
    private int _quantity;

    public Guid UserId { get; set; }
    public Guid CatalogItemId { get; set; }
    
    public int Quantity
    { 
        get => _quantity;
        set
        {
            if (value < 0) throw new NegativeQuantityException(value);
            _quantity = value;
        }
    }

    public DateTimeOffset AcquiredDateUtc { get; set; }
}
