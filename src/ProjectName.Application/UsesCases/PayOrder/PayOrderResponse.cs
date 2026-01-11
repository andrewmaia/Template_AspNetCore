using ProjectName.Application.Common;

namespace ProjectName.Application.UsesCases.PayOrder;
public class PayOrderResponse: ResultResponse
{
    public Guid OrderId { get; set; }

}
 