using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.Common.Events;
using ProjectName.Application.EventHandlers;
using ProjectName.Application.Execution;
using ProjectName.Application.UsesCases.CreateOrder;
using ProjectName.Application.UsesCases.PayOrder;
using ProjectName.Application.UsesCases.ProcessOrderPaid;
using ProjectName.Application.UsesCases.SendEmailToOpenOrders;
using ProjectName.Domain.DomainEvents;
using ProjectName.Domain.Services;


namespace ProjectName.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUseCase<CreateOrderRequest, CreateOrderResponse>,CreateOrderUseCase>();
        services.AddScoped<IUseCase<PayOrderRequest, PayOrderResponse>, PayOrderUseCase>();
        services.AddScoped<IUseCase<SendEmailToOpenOrdersRequest, SendEmailToOpenOrdersResponse>, SendEmailToOpenOrdersUseCase>();
        services.AddScoped<IUseCase<ProcessOrderPaidRequest, ProcessOrderPaidResponse>, ProcessOrderPaidUseCase>();
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient<DomainEventsDispatcher>();
        services.AddScoped<IDomainEventHandler<OrderPaidDomainEvent>, IssueInvoiceOnOrderPaidHandler>();
        services.AddScoped<RequestExecutor>();
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<OrderDomainService>();
        return services;
    }
}
