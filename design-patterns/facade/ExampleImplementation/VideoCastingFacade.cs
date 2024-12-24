namespace DesignPatterns.Facade.ExampleImplementation;

public sealed class VideoCastingFacade(IDeviceExplorer deviceExplorer)
{
    public async Task CastAsync(Guid deviceId, Guid videoId)
    {
        IDevice device = await deviceExplorer.GetAsync(deviceId);

        if (device is null || device is not ISmartTvDevice smartTv)
            throw new InvalidOperationException("Smart Tv not found");

        IDeviceConnection connection;
        try
        {
            connection = await smartTv.GetConnectionAsync();
        }
        catch
        {
            connection = await smartTv.TurnOnAsync();
            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        IApp app = await connection.LaunchAppAsync("com.google.youtube");

        if (app is null || app is not IVideoApp videoApp)
            throw new InvalidOperationException("YouTube app not found");

        await videoApp.PlayAsync(videoId);
    }
}