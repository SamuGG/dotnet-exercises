using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Game.Common.Domain.Events;

namespace Game.Common.Domain.Entities;

public abstract class BaseEntity
{
    private readonly List<BaseEvent> _domainEvents = new();
    
    public Guid Id { get; set; }

    [NotMapped]
    public bool DoesNotHaveDomainEvents => 
        _domainEvents.Count == 0;

    public BaseEvent[] GetDomainEventsArray() => 
        _domainEvents.ToArray();

    public void AddDomainEvent([NotNull] BaseEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        _domainEvents.Add(domainEvent);
    }
    
    public void ClearDomainEvents() => 
        _domainEvents.Clear();
}