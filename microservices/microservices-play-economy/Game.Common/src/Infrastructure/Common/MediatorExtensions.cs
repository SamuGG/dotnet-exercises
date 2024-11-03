using System.Diagnostics.CodeAnalysis;
using Game.Common.Application.Common.Interfaces;
using Game.Common.Domain.Entities;
using MediatR;

namespace Game.Common.Infrastructure.Common;

public static class MediatorExtensions
{
    public static async Task DispatchAndClearDomainEvents<T>(this IMediator mediator, [NotNull] ITrackedRepository<T> repository)
        where T : BaseEntity
    {
        ArgumentNullException.ThrowIfNull(repository);
        
        foreach (var trackedEntity in repository.GetTrackedEntitiesArray())
        {
            if (trackedEntity.DoesNotHaveDomainEvents)
                continue;

            var domainEvents = trackedEntity.GetDomainEventsArray();
            trackedEntity.ClearDomainEvents();

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }

        repository.UntrackAllWithoutDomainEvents();
    }
}