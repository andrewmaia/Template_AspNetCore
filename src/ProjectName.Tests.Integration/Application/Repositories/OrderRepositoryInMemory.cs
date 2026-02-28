using Microsoft.EntityFrameworkCore;
using ProjectName.Application.Repositories;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Enums;

namespace ProjectName.Tests.Integration.Application.Repositories;

public class OrderRepositoryInMemory : IOrderRepository
{
    private readonly DbSet<Order> _orders;

    public OrderRepositoryInMemory(DbContext context)
    {
        _orders = context.Set<Order>();
    }

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        var entity = await _orders.FindAsync(id);
        return entity;
    }

    public IEnumerable<Order> GetOpenOrders()
    {
        return _orders
            .Where(o => o.Status == OrderStatus.Open)
            .ToList();
    }
}