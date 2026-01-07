using ProjectName.Application.Interfaces;
using ProjectName.Application.Interfaces.Repositories;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Enums;

namespace ProjectName.Application.UsesCases;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderUseCase(IOrderRepository orderRepository, IUnitOfWork uow)
    {
        _orderRepository = orderRepository;
        _unitOfWork = uow;
    }

    public async Task<Guid> Execute(decimal totalAmount)
    {
        var order = new Order(OrderStatus.Open, totalAmount);

        _orderRepository.Add(order);
        await _unitOfWork.CommitAsync();

        return order.Id;
    }
}
