using AutoMapper;
using Game.Catalog.Application.CatalogItems.Queries.Find;
using Game.Catalog.Application.Commands.Create;
using Game.Catalog.Domain.Entities;

namespace Game.Catalog.Application.Common.Mappings;

public class CatalogItemProfile : Profile
{
    public CatalogItemProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>();
        CreateMap<CreateCatalogItemCommand, CatalogItem>()
            .ForMember(dest => dest.CreatedUtc, opt => opt.MapFrom<CurrentTimeResolver>());
    }
}