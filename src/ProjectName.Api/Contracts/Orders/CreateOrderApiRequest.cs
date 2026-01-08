namespace ProjectName.Api.Contracts.Orders;

public class CreateOrderApiRequest
{
    public decimal TotalAmount { get; }

    public CreateOrderApiRequest(decimal totalAmount)
    {
        TotalAmount = totalAmount;
    }
}