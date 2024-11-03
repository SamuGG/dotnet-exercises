namespace Game.Catalog.Domain.Exceptions;

public class NegativePriceException : Exception
{
    public NegativePriceException() : base()
    {}

    public NegativePriceException(string? message) : base(message)
    {}

    public NegativePriceException(string? message, Exception? innerException) : base(message, innerException)
    {}

    public NegativePriceException(decimal unsupportedValue)
        : base($"The value {unsupportedValue} is not a valid price. Only positive values are allowed.")
    {}
}