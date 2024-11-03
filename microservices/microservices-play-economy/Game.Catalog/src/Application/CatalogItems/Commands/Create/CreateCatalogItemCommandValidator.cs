using FluentValidation;

namespace Game.Catalog.Application.Commands.Create;

internal class CreateCatalogItemCommandValidator : AbstractValidator<CreateCatalogItemCommand>
{
    public CreateCatalogItemCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Price).InclusiveBetween(decimal.Zero, 1000.0m);
    }
}