namespace Game.Catalog.Domain.Exceptions;

public class NegativePriceException : Exception
{
    public NegativePriceException(decimal unsupportedValue) 
        : base($"The value {unsupportedValue} is not a valid price. Only positive values are allowed.")
    {}
}