namespace DesignPatterns.Facade.ExampleImplementation;

public interface IDeviceExplorer
{
    Task<IDevice> GetAsync(Guid deviceId);
}

public interface IDevice
{
    Task<IDeviceConnection> GetConnectionAsync();
}

public interface ISmartTvDevice : IDevice
{
    Task<IDeviceConnection> TurnOnAsync();
}

public interface IDeviceConnection
{
    Task<IApp> LaunchAppAsync(string appId);
}

public interface IApp;

public interface IVideoApp : IApp
{
    Task PlayAsync(Guid videoId);
}