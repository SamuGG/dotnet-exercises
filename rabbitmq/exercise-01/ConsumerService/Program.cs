using ConsumerService.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddConsumer<GreetingNotificationConsumer>();
    busConfigurator.UsingRabbitMq((context, rabbitMqConfigurator) =>
        rabbitMqConfigurator.ConfigureEndpoints(context));
});

var app = builder.Build();
app.Run();