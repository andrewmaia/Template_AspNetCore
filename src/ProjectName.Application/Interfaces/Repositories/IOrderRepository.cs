using ProjectName.Domain.Entities;

namespace ProjectName.Application.Interfaces.Repositories;

public interface IOrderRepository
{

    void Add(Order order);
    Order? GetById(int id);
    IEnumerable<Order> GetOpenOrders();
}
