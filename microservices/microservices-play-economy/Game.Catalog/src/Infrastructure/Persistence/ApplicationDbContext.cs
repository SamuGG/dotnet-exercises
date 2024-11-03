using System.Diagnostics.CodeAnalysis;
using Game.Catalog.Application.Common.Interfaces;
using Game.Catalog.Domain.Entities;
using Game.Common.Infrastructure.Common;
using Game.Common.Application.Common.Interfaces;
using MediatR;

namespace Game.Catalog.Infrastructure.Persistence;

public class ApplicationDbContext : IApplicationDbContext
{
    private readonly IMediator _mediator;

    public ITrackedRepository<CatalogItem> CatalogItems { get; init; }

    public ApplicationDbContext(
        [NotNull] IMediator mediator, 
        [NotNull] ITrackedRepository<CatalogItem> catalogItemsRepository)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(catalogItemsRepository);
        
        _mediator = mediator;
        CatalogItems = catalogItemsRepository;
    }

    public async Task SaveChangesAsync() => 
        await _mediator.DispatchAndClearDomainEvents(CatalogItems);
}