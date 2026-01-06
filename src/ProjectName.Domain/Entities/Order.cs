using ProjectName.Domain.Enums;

namespace ProjectName.Domain.Entities;

public class Order
{
    public Order(string id, OrderStatus status )
    {
        Id = id;
        Status = status;
    }
    public string Id { get; set; }
    public OrderStatus Status { get; set; }

    public void Pay()
    {
        if (Status != OrderStatus.Open)
            throw new Exception("Pedido inválido");

        Status = OrderStatus.Paid;
    }
}
