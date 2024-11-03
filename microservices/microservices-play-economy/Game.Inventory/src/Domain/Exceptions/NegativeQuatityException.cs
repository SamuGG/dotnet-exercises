namespace Game.Inventory.Domain.Exceptions;

public class NegativeQuantityException : Exception
{
    public NegativeQuantityException(decimal unsupportedValue) 
        : base($"The value {unsupportedValue} is not a valid quantity. Only positive values are allowed.")
    {}
}