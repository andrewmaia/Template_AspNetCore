using ProjectName.Domain.Enums;

namespace ProjectName.Domain.Entities;

public class Order
{
    public Order(OrderStatus status, decimal totalAmount)
    {
        Id = Guid.NewGuid();
        Status = status;
        TotalAmount = totalAmount;
    }

    public Order(Guid id, OrderStatus status,  decimal totalAmount)
    {
        Id =id;
        Status = status;
        TotalAmount = totalAmount;
    }
    public Guid Id { get; private set; }
    public OrderStatus Status { get; private set; }

    public decimal TotalAmount { get; private set; }

    public void Pay()
    {
        if (Status != OrderStatus.Open)
            throw new InvalidOperationException("Pedido inválido");

        Status = OrderStatus.Paid;
    }
}
