using FluentValidation;
using Game.Catalog.Contracts.Events;

namespace Game.Inventory.Application.CatalogItems.Consumers;

internal class CatalogItemCreatedValidator : AbstractValidator<ICatalogItemCreatedEvent>
{
    public CatalogItemCreatedValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
    }
}