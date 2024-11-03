using FluentValidation;
using Game.Catalog.Contracts.Events;

namespace Game.Inventory.Application.CatalogItems.Consumers;

internal class CatalogItemUpdatedValidator : AbstractValidator<ICatalogItemUpdatedEvent>
{
    public CatalogItemUpdatedValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
    }
}