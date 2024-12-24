using DesignPatterns.Facade.BasicImplementation;
using DesignPatterns.Facade.ExampleImplementation;

Facade facade = new();
facade.ComplexOperation();

// ---

Guid deviceId = Guid.NewGuid();
Guid videoId = Guid.NewGuid();
IDeviceExplorer deviceExplorer = new DeviceExplorerFake();
VideoCastingFacade castingFacade = new(deviceExplorer);
await castingFacade.CastAsync(deviceId, videoId);