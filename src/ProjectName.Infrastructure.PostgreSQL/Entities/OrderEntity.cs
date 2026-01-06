using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.PostgreSQL.Entities;

public class OrderEntity
{
    public OrderEntity(string id, int status)
    {
        Id = id;
        Status = status;
    }
    public string Id { get; set; }
    public int Status { get; set; }
}
