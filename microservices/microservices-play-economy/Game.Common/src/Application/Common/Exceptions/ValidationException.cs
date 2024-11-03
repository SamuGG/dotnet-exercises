using FluentValidation.Results;

namespace Game.Common.Application.Common.Exceptions;

public class ValidationException : Exception
{
    private readonly Dictionary<string, string[]> _errors = new ();

    public IDictionary<string, string[]> Errors => _errors;

    public ValidationException()
        : this("One or more validation failures have occurred.")
    {}

    public ValidationException(string? message) : base(message)
    {}

    public ValidationException(string? message, Exception? innerException) : base(message, innerException)
    {}

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        _errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}