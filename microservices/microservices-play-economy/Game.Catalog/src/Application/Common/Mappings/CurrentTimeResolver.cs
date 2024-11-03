using AutoMapper;
using Game.Common.Application.Services;

namespace Game.Catalog.Application.Common.Mappings;

internal class CurrentTimeResolver : IValueResolver<object, object, DateTimeOffset>
{
    private readonly IDateTimeService _dateTimeService;

    public CurrentTimeResolver(IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(dateTimeService);
        _dateTimeService = dateTimeService;
    }

    public DateTimeOffset Resolve(
        object source, 
        object destination, 
        DateTimeOffset destMember, 
        ResolutionContext context) => 
            _dateTimeService.UtcNow;
}