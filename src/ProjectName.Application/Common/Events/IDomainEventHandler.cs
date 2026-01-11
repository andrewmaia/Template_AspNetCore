using ProjectName.Domain.DomainEvents.Common;

namespace ProjectName.Application.Common.Events;
public interface IDomainEventHandler<in T> where T : IDomainEvent
{
    Task Handle(T domainEvent, CancellationToken cancellationToken = default);
}