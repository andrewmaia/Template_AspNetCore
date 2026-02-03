using ProjectName.Application.Common;

namespace ProjectName.Application.UseCases.PayOrder;
public class PayOrderResponse: ResultResponse
{
    public Guid OrderId { get; set; }

}
 