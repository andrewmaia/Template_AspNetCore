using ProjectName.Application.Interfaces.Repositories;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Enums;
using ProjectName.Infrastructure.PostgreSQL.Context;
using ProjectName.Infrastructure.PostgreSQL.Entities;

namespace ProjectName.Infrastructure.PostgreSQL.Repositories;

public class OrderRepository: IOrderRepository
{
    private readonly ProjectNameDbContext _db;

    public OrderRepository(ProjectNameDbContext db)
    {
        _db = db;
    }

    private Order ToDomain(OrderEntity entity) => new Order(entity.Id,(OrderStatus)entity.Status,entity.TotalAmount);

    private OrderEntity ToEntity(Order domain)=> new OrderEntity (domain.Id,(int)domain.Status, domain.TotalAmount);

    public void Add(Order order)
    {
        var entity = ToEntity(order);
        _db.Orders.Add(entity);
    }

    public Order? GetById(int id)
    {
        var entity = _db.Orders.Find(id);
        return entity == null ? null : ToDomain(entity);
    }

    public IEnumerable<Order> GetOpenOrders()
    {
        return _db.Orders
            .Where(o => o.Status == (int)OrderStatus.Open)
            .OrderBy(o => o.Id)
            .Select(ToDomain)
            .ToList();
    }
}
