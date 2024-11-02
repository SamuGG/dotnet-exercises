using Contracts.Greetings;
using MassTransit;

namespace ConsumerService.Consumers;

public class GreetingNotificationConsumer : IConsumer<GreetingNotification>
{
    private readonly ILogger<GreetingNotificationConsumer> _logger;

    public GreetingNotificationConsumer(ILogger<GreetingNotificationConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<GreetingNotification> context)
    {
        _logger.LogInformation(
            "Received greeting notification \"{Message}\"",
            $"{context.Message.Greeting}, {context.Message.Name}!");

        return Task.CompletedTask;
    }
}