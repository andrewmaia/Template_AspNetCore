namespace ProjectName.Application.UsesCases.CreateOrder;
public  class CreateOrderRequest
{
    public decimal TotalAmount { get; }

    public CreateOrderRequest(decimal totalAmount)
    {
        TotalAmount = totalAmount;
    }
}