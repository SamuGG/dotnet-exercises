using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Game.Catalog.Application.Common.Interfaces;
using Game.Catalog.Domain.Entities;
using Game.Common.Application.Common.Exceptions;
using MediatR;

namespace Game.Catalog.Application.CatalogItems.Queries.Find;

public record FindCatalogItemByIdQuery(Guid Id) : IRequest<CatalogItemDto>;

internal class FindCatalogItemByIdQueryHandler : IRequestHandler<FindCatalogItemByIdQuery, CatalogItemDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public FindCatalogItemByIdQueryHandler([NotNull] IApplicationDbContext dbContext, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(mapper);

        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CatalogItemDto> Handle(FindCatalogItemByIdQuery request, CancellationToken cancellationToken)
    {
        var catalogItem = await _dbContext.CatalogItems.FindOneAsync(request.Id);
        if (catalogItem is null)
            throw new NotFoundException(nameof(CatalogItem), request.Id);

        return _mapper.Map<CatalogItem, CatalogItemDto>(catalogItem);
    }
}