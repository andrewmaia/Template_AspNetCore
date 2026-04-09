using ProjectName.Application.Repositories;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Enums;
using ProjectName.Infrastructure.PostgreSQL.Context;

namespace ProjectName.Infrastructure.PostgreSQL.Repositories;

public class OrderRepository: IOrderRepository
{
    private readonly ProjectNameDbContext _db;

    public OrderRepository(ProjectNameDbContext db)
    {
        _db = db;
    }

    public void Add(Order order)
    {
        _db.Orders.Add(order);
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        var entity = await _db.Orders.FindAsync(id);
        return entity;
    }

    public IEnumerable<Order> GetOpenOrders()
    {
        return _db.Orders
            .ToList();
            //.Where(o => o.Status == OrderStatus.Open);
    }
}
