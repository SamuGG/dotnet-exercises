using FluentValidation;

namespace Game.Inventory.Application.Commands.Grant;

internal class GrantCatalogItemCommandValidator : AbstractValidator<GrantCatalogItemCommand>
{
    public GrantCatalogItemCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.CatalogItemId).NotEqual(Guid.Empty);
        RuleFor(command => command.Quantity).InclusiveBetween(0, 1000);
    }
}