using ProjectName.Domain.Entities;

namespace ProjectName.Application.Repositories;

public interface IOrderRepository
{

    void Add(Order order);
    Order? GetById(Guid id);
    IEnumerable<Order> GetOpenOrders();
}
