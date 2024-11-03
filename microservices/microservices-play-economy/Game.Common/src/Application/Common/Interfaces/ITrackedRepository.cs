using Game.Common.Domain.Entities;

namespace Game.Common.Application.Common.Interfaces;

public interface ITrackedRepository<T> : IRepository<T> where T : BaseEntity
{
    T[] GetTrackedEntitiesArray();
    void UntrackAllWithoutDomainEvents();
}