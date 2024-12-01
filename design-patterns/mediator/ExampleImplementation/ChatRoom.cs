namespace DesignPatterns.Mediator.ExampleImplementation;

public class ChatRoom : IChatMediator
{
    private readonly List<User> _users = [];

    public void AddUser(User user)
    {
        _users.Add(user);
        user.SetMediator(this);
    }

    public void Notify(User sender, string message)
    {
        foreach (User user in _users)
        {
            if (!ReferenceEquals(user, sender))
                user.Receive(message, sender.Name);
        }
    }
}