namespace Game.Catalog.Application.CatalogItems.Queries.Find;

public record CatalogItemDto(Guid Id, string? Name, string? Description, decimal Price, DateTimeOffset CreatedUtc);