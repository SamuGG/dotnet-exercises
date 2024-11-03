using FluentValidation;

namespace Game.Catalog.Application.Commands.Update;

internal class UpdateCatalogItemCommandValidator : AbstractValidator<UpdateCatalogItemCommand>
{
    public UpdateCatalogItemCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Price).InclusiveBetween(decimal.Zero, 1000.0m);
    }
}