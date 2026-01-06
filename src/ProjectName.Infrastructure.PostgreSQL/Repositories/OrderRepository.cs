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


    private Order ToDomain(OrderEntity entity) => new Order( entity.Id,(OrderStatus)entity.Status);

    private OrderEntity ToEntity(Order order)=> new OrderEntity ( order.Id,(int)order.Status);

    public void Add(Order order)
    {
        var entity = ToEntity(order);
        _db.Orders.Add(entity);
        _db.SaveChanges();
    }

    public Order? GetById(int id)
    {
        var entity = _db.Orders.Find(id);
        return entity == null ? null : ToDomain(entity);
    }
}
