using Game.Catalog.Contracts.Events;
using Game.Inventory.Application.Common.Interfaces;
using Game.Inventory.Domain.Entities.Extensions;
using MassTransit;

namespace Game.Inventory.Application.CatalogItems.Consumers;

public class CatalogItemDeletedConsumerDefinition : ConsumerDefinition<CatalogItemDeletedConsumer>
{}

public class CatalogItemDeletedConsumer : IConsumer<ICatalogItemDeletedEvent>
{
    private readonly IApplicationDbContext _dbContext;

    public CatalogItemDeletedConsumer(IApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<ICatalogItemDeletedEvent> context)
    {
        var catalogItem = await _dbContext.CatalogItems.FindOneAndDeleteAsync(context.Message.Id);

        if (catalogItem is not null)
            catalogItem.AddDeletedEvent();

        await _dbContext.SaveChangesAsync();
    }
}