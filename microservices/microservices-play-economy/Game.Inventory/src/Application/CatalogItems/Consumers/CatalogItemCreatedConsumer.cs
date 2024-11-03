using AutoMapper;
using Game.Catalog.Contracts.Events;
using Game.Inventory.Application.Common.Interfaces;
using Game.Inventory.Domain.Entities;
using Game.Inventory.Domain.Entities.Extensions;
using MassTransit;

namespace Game.Inventory.Application.CatalogItems.Consumers;

public class CatalogItemCreatedConsumerDefinition : ConsumerDefinition<CatalogItemCreatedConsumer>
{}

public class CatalogItemCreatedConsumer : IConsumer<ICatalogItemCreatedEvent>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CatalogItemCreatedConsumer(IApplicationDbContext dbContext, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(mapper);

        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<ICatalogItemCreatedEvent> context)
    {
        var catalogItem = await _dbContext.CatalogItems.FindOneAsync(context.Message.Id);

        if (catalogItem is null)
        {
            catalogItem = _mapper.Map<CatalogItem>(context.Message);
            await _dbContext.CatalogItems.AddNewAsync(catalogItem);
            catalogItem.AddCreatedEvent();
        }
        else
        {
            _mapper.Map<ICatalogItemCreatedEvent, CatalogItem>(context.Message, catalogItem);
            catalogItem = await _dbContext.CatalogItems.FindOneAndReplaceAsync(catalogItem);
            catalogItem.AddUpdatedEvent();
        }

        await _dbContext.SaveChangesAsync();
    }
}