using ProjectName.Domain.Enums;

namespace ProjectName.Infrastructure.PostgreSQL.Entities;

public class OrderEntity
{
    public OrderEntity(Guid id, OrderStatus status,decimal totalAmount)
    {
        Id = id;
        Status = status;
        TotalAmount = totalAmount;
    }
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; private set; }
}
