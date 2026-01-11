using ProjectName.Application.Common;

namespace ProjectName.Application.UsesCases.CreateOrder;
public class CreateOrderResponse : ResultResponse
{
    public Guid? OrderId { get; set; }
}
