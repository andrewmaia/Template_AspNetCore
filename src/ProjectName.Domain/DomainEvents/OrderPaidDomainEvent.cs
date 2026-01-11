using ProjectName.Domain.DomainEvents.Common;
using ProjectName.Domain.Entities;

namespace ProjectName.Domain.DomainEvents;
public class OrderPaidDomainEvent: IDomainEvent
{
    public Guid OrderId { get; }
    public OrderPaidDomainEvent(Guid orderId)
    {
        OrderId = orderId;
    }
}
