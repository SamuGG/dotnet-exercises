using System.Diagnostics.CodeAnalysis;
using Game.Common.Application.Common.Interfaces;
using Game.Common.Domain.Entities;

namespace Game.Common.Infrastructure.Persistence;

public class EntityTracker<T> : IEntityTracker<T> where T : BaseEntity
{
    private readonly HashSet<T> _trackedEntities = new();

    public void Track([NotNull] T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _trackedEntities.Add(entity);
    }

    public T[] GetEntitiesArray() => 
        _trackedEntities.ToArray();

    public void RemoveAllWithoutDomainEvents() =>
        _trackedEntities.RemoveWhere(entity => entity.DoesNotHaveDomainEvents);
}