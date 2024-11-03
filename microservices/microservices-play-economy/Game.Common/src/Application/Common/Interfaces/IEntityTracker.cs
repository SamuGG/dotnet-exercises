using Game.Common.Domain.Entities;

namespace Game.Common.Application.Common.Interfaces;

public interface IEntityTracker<T> where T : BaseEntity
{
    void Track(T entity);
    T[] GetEntitiesArray();
    void RemoveAllWithoutDomainEvents();
}