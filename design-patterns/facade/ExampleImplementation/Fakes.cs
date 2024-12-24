namespace DesignPatterns.Facade.ExampleImplementation;

public sealed class VideoAppFake : IVideoApp
{
    public Task PlayAsync(Guid videoId)
    {
        Console.WriteLine($"Playing video '{videoId}'");
        return Task.CompletedTask;
    }
}

public sealed class DeviceConnectionFake : IDeviceConnection
{
    public Task<IApp> LaunchAppAsync(string appId)
    {
        Console.WriteLine($"Launching app '{appId}'");
        return Task.FromResult<IApp>(new VideoAppFake());
    }
}

public sealed class SmartTvFake : ISmartTvDevice
{
    public Task<IDeviceConnection> GetConnectionAsync()
    {
        Console.WriteLine("Tv is off");
        return Task.FromException<IDeviceConnection>(new TimeoutException());
    }

    public Task<IDeviceConnection> TurnOnAsync()
    {
        Console.WriteLine("Turning SmartTv on");
        return Task.FromResult<IDeviceConnection>(new DeviceConnectionFake());
    }
}

public sealed class DeviceExplorerFake : IDeviceExplorer
{
    public Task<IDevice> GetAsync(Guid deviceId)
    {
        Console.WriteLine($"Searching for device '{deviceId}'");
        return Task.FromResult<IDevice>(new SmartTvFake());
    }
}
