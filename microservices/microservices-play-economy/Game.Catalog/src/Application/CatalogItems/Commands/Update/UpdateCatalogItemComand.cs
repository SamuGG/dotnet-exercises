using Game.Common.Application.Common.Exceptions;
using Game.Catalog.Application.Common.Interfaces;
using Game.Catalog.Domain.Entities;
using MediatR;
using Game.Catalog.Domain.Entities.Extensions;

namespace Game.Catalog.Application.Commands.Update;

public record UpdateCatalogItemCommand(Guid Id, string Name, string? Description, decimal Price) : IRequest;

internal class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateCatalogItemCommandHandler(IApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = await _dbContext.CatalogItems.FindOneAsync(request.Id);

        if (catalogItem is null)
            throw new NotFoundException(nameof(CatalogItem), request.Id);

        catalogItem.Name = request.Name;
        catalogItem.Description = request.Description;
        catalogItem.Price = request.Price;

        catalogItem = await _dbContext.CatalogItems.FindOneAndReplaceAsync(catalogItem);
        catalogItem.AddUpdatedEvent();
        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }
}