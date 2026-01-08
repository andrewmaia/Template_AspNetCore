using ProjectName.Application.Interfaces;
using ProjectName.Application.Interfaces.Repositories;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Enums;
using ProjectName.Domain.Services;

namespace ProjectName.Application.UsesCases;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly OrderDomainService _orderService;

    public CreateOrderUseCase(IOrderRepository orderRepository, IUnitOfWork unitOfWork, OrderDomainService orderService)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _orderService = orderService;
    }

    public async Task<Guid> ExecuteAsync(decimal totalAmount)
    {

        var finalAmount = _orderService.ApplyDiscount(totalAmount);

        var order = new Order(OrderStatus.Open, finalAmount);

        _orderRepository.Add(order);
        await _unitOfWork.CommitAsync();

        return order.Id;
    }
}
