using ProjectName.Application.Common;

namespace ProjectName.Application.UseCases.CreateOrder;
public class CreateOrderResponse : ResultResponse
{
    public Guid? OrderId { get; set; }
}
