using Game.Catalog.Domain.Exceptions;
using Game.Common.Domain.Entities;

namespace Game.Catalog.Domain.Entities;

public class CatalogItem : BaseEntity
{
    private decimal _price;

    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price
    {
        get => _price;
        set
        {
            if (value < decimal.Zero) throw new NegativePriceException(value);
            _price = value;
        }
    }
    public DateTimeOffset CreatedUtc { get; set; }
}