using ProjectName.Application.Common;

namespace ProjectName.Application.UseCases.ProcessOrderPaid;
public class ProcessOrderPaidResponse : ResultResponse
{
    public Guid OrderId { get; set; }

}
