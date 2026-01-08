using ProjectName.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Application.UsesCases.CreateOrder;
public class CreateOrderResponse : ResultResponse
{
    public Guid? OrderId { get; set; }
}
