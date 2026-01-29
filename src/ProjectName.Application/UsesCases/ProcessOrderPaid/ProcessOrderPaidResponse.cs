using ProjectName.Application.Common;

namespace ProjectName.Application.UsesCases.ProcessOrderPaid;
public class ProcessOrderPaidResponse : ResultResponse
{
    public Guid OrderId { get; set; }

}
