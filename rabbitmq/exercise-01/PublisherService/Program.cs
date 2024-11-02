using Contracts.Greetings;
using MassTransit;
using SenderService.Clients;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<NotificationsClient>();
builder.Services.AddMassTransit(busConfigurator => busConfigurator.UsingRabbitMq());
var app = builder.Build();

app.MapPost("/greeting-requests", async (GreetingRequest request, NotificationsClient client) =>
{
    await client.SendGreetingNotification(request.Greeting, request.Name).ConfigureAwait(false);
    app.Logger.LogInformation("Sent greeting notification for {TargetName}", request.Name);
    return Results.Accepted(value: request);
});

app.Run();