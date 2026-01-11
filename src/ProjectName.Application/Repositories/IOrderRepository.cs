using ProjectName.Domain.Entities;

namespace ProjectName.Application.Repositories;

public interface IOrderRepository
{

    void Add(Order order);
    Task<Order?> GetById(Guid id);
    IEnumerable<Order> GetOpenOrders();
}
