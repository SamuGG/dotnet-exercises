using Game.Common.Application.Common.Exceptions;
using Game.Common.WebApi.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Game.Catalog.WebApi.Filters;

internal class ApiExceptionFilter : ExceptionFilterAttribute
{
    private readonly HttpCodeDescription _httpCodeDescription;
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilter(HttpCodeDescription httpCodeDescription)
    {
        ArgumentNullException.ThrowIfNull(httpCodeDescription);
        _httpCodeDescription = httpCodeDescription;

        // Register known exception types and handlers.
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(NotFoundException), HandleNotFoundException }
        };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        var uriBuilder = new UriBuilder(_httpCodeDescription.ServiceUrl);
        uriBuilder.Fragment = _httpCodeDescription.Http500InternalServerError;
        var problemDetailsTypeUri = uriBuilder.Uri;

        var details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Type = problemDetailsTypeUri.ToString()
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }

    private void HandleValidationException(ExceptionContext context)
    {
        var uriBuilder = new UriBuilder(_httpCodeDescription.ServiceUrl);
        uriBuilder.Fragment = _httpCodeDescription.Http400BadRequest;
        var problemDetailsTypeUri = uriBuilder.Uri;

        var exception = context.Exception as ValidationException;
        var details = new ValidationProblemDetails(exception!.Errors)
        {
            Type = problemDetailsTypeUri.ToString()
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
        var uriBuilder = new UriBuilder(_httpCodeDescription.ServiceUrl);
        uriBuilder.Fragment = _httpCodeDescription.Http404NotFound;
        var problemDetailsTypeUri = uriBuilder.Uri;

        var exception = context.Exception as NotFoundException;
        var details = new ProblemDetails()
        {
            Type = problemDetailsTypeUri.ToString(),
            Title = "The specified resource was not found.",
            Detail = exception?.Message
        };

        context.Result = new NotFoundObjectResult(details);
        context.ExceptionHandled = true;
    }
}