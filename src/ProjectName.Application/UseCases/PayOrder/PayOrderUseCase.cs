using ProjectName.Application.Common;
using ProjectName.Application.Common.Events;
using ProjectName.Application.Interfaces;
using ProjectName.Application.Repositories;


namespace ProjectName.Application.UseCases.PayOrder;
public class PayOrderUseCase : IUseCase<PayOrderRequest, PayOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DomainEventsDispatcher _domainEventsDispatcher;

    public PayOrderUseCase(IOrderRepository orderRepository, IUnitOfWork unitOfWork, DomainEventsDispatcher domainEventsDispatche)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _domainEventsDispatcher = domainEventsDispatche;
    }

    public async Task<PayOrderResponse> ExecuteAsync(PayOrderRequest request)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        var response = new PayOrderResponse();
        if (order is null)
        {
            response.OrderId = request.OrderId;
            return response;
        }

        order.Pay();
        await _domainEventsDispatcher.DispatchAsync(order.DomainEvents);
        order.ClearDomainEvents();
        await _unitOfWork.CommitAsync();

        response.OrderId = order.Id;
        return response;
    }
}
