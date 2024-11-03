using AutoMapper;
using Game.Catalog.Contracts.Events;
using Game.Inventory.Domain.Entities;

namespace Game.Inventory.Application.Common.Mappings;

internal class CatalogItemProfile : Profile
{
    public CatalogItemProfile()
    {
        CreateMap<ICatalogItemCreatedEvent, CatalogItem>();
        CreateMap<ICatalogItemUpdatedEvent, CatalogItem>();
    }
}