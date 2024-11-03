using Game.Common.Application.Common.Exceptions;
using Game.Catalog.Application.Common.Interfaces;
using Game.Catalog.Domain.Entities;
using MediatR;
using Game.Catalog.Domain.Entities.Extensions;

namespace Game.Catalog.Application.Commands.Delete;

public record DeleteCatalogItemCommand(Guid Id) : IRequest;

internal class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteCatalogItemCommandHandler(IApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = await _dbContext.CatalogItems.FindOneAsync(request.Id);

        if (catalogItem is null)
            throw new NotFoundException(nameof(CatalogItem), request.Id);

        catalogItem = await _dbContext.CatalogItems.FindOneAndDeleteAsync(request.Id);
        catalogItem.AddDeletedEvent();
        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }
}