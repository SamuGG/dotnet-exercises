using AutoMapper;
using Game.Catalog.Application.Common.Interfaces;
using Game.Catalog.Domain.Entities;
using Game.Catalog.Domain.Entities.Extensions;
using MediatR;

namespace Game.Catalog.Application.Commands.Create;

public record CreateCatalogItemCommand(string Name, string? Description, decimal Price) : IRequest<Guid>;

internal class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateCatalogItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(mapper);

        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = _mapper.Map<CatalogItem>(request);
        await _dbContext.CatalogItems.AddNewAsync(catalogItem);
        catalogItem.AddCreatedEvent();
        await _dbContext.SaveChangesAsync();

        return catalogItem.Id;
    }
}