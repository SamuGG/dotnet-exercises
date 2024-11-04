using ServiceConsumer.Services;
using ServiceContainer;

var services = new ServiceCollection();

// Flip these lines to register a service using different overloads
services.AddSingleton<IConsoleWriter, ConsoleWriter>();
// services.AddSingleton<ConsoleWriter>();
// services.AddSingleton(serviceProvider => new ConsoleWriter());

// Flip these lines to see different results
services.AddSingleton<IGuidProvider, GuidProvider>();
// services.AddTransient<IGuidProvider, GuidProvider>();

var serviceProvider = services.BuildServiceProvider();
var writerService = serviceProvider.GetService<IConsoleWriter>();
// var writerService = serviceProvider.GetService<ConsoleWriter>();
var guidGenerator1 = serviceProvider.GetService<IGuidProvider>();
var guidGenerator2 = serviceProvider.GetService<IGuidProvider>();

if (writerService is null)
    return;

if (guidGenerator1 is null || guidGenerator2 is null)
    return;

writerService.WriteLine(guidGenerator1.Value.ToString());
writerService.WriteLine(guidGenerator2.Value.ToString());
