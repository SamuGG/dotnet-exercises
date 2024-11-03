using Game.Common.Application.Services;

namespace Game.Common.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}