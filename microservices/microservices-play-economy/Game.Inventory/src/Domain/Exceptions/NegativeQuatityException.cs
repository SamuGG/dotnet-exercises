namespace Game.Inventory.Domain.Exceptions;

public class NegativeQuantityException : Exception
{
    public NegativeQuantityException() : base()
    {}

    public NegativeQuantityException(string? message) : base(message)
    {}

    public NegativeQuantityException(string? message, Exception? innerException) : base(message, innerException)
    {}

    public NegativeQuantityException(decimal unsupportedValue)
        : this($"The value {unsupportedValue} is not a valid quantity. Only positive values are allowed.")
    {}
}