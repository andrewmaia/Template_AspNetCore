using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.PostgreSQL.Entities;

public class OrderEntity
{
    public OrderEntity(Guid id, int status,decimal totalAmount)
    {
        Id = id;
        Status = status;
        TotalAmount = totalAmount;
    }
    public Guid Id { get; set; }
    public int Status { get; set; }
    public decimal TotalAmount { get; private set; }
}
