using Contracts.Greetings;
using MassTransit;

namespace SenderService.Clients;

public class NotificationsClient
{
    private const string QueueAddress = "queue:GreetingNotification";
    private readonly IBus _bus;

    public NotificationsClient(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendGreetingNotification(string greeting, string name)
    {
        var endpoint = await _bus.GetSendEndpoint(new Uri(QueueAddress));
        GreetingNotification notification = new(greeting, name);
        await endpoint.Send(notification);
    }
}