using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Game.Catalog.Application.Common.Interfaces;
using Game.Catalog.Domain.Entities;
using MediatR;

namespace Game.Catalog.Application.CatalogItems.Queries.Find;

public record FindCatalogItemsQuery() : IRequest<IReadOnlyCollection<CatalogItemDto>>;

internal class FindCatalogItemsQueryHandler : IRequestHandler<FindCatalogItemsQuery, IReadOnlyCollection<CatalogItemDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public FindCatalogItemsQueryHandler([NotNull] IApplicationDbContext dbContext, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(mapper);

        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<CatalogItemDto>> Handle(FindCatalogItemsQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<IReadOnlyCollection<CatalogItem>, IReadOnlyCollection<CatalogItemDto>>(await _dbContext.CatalogItems.GetAllAsync());
}