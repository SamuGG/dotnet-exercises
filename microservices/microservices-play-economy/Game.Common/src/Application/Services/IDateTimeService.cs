namespace Game.Common.Application.Services;

public interface IDateTimeService
{
    DateTimeOffset UtcNow { get; }
}