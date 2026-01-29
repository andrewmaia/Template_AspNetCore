using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Application.UsesCases.ProcessOrderPaid;

public class ProcessOrderPaidRequest
{
    public Guid OrderId { get; }

    public ProcessOrderPaidRequest(Guid orderId)
    {
        OrderId = orderId;
    }
}
