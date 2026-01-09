using Microsoft.EntityFrameworkCore;
using ProjectName.Application.Repositories;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Enums;
using ProjectName.Infrastructure.PostgreSQL.Entities;

namespace ProjectName.Tests.Integration.Application.Repositories;

public class OrderRepositoryInMemory : IOrderRepository
{
    private readonly DbSet<OrderEntity> _orders;

    private Order ToDomain(OrderEntity entity) => new Order(entity.Id, (OrderStatus)entity.Status, entity.TotalAmount);

    private OrderEntity ToEntity(Order domain) => new OrderEntity(domain.Id, (int)domain.Status, domain.TotalAmount);

    public OrderRepositoryInMemory(DbContext context)
    {
        _orders = context.Set<OrderEntity>();
    }

    public void Add(Order order)
    {
        _orders.Add(ToEntity(order));
    }

    public Order? GetById(Guid id)
    {
        var entity = _orders.Find(id);
        return entity == null ? null : ToDomain(entity);
    }

    public IEnumerable<Order> GetOpenOrders()
    {
        return _orders
            .Where(o => o.Status == (int)OrderStatus.Open)
            .Select(ToDomain)
            .ToList();
    }
}