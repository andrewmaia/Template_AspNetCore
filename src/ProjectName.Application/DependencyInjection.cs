using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.UsesCases.CreateOrder;
using ProjectName.Application.UsesCases.SendEmailToOpenOrders;
using ProjectName.Domain.Services;
using FluentValidation;
using ProjectName.Application.Execution;


namespace ProjectName.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUseCase<CreateOrderRequest, CreateOrderResponse>,CreateOrderUseCase>();
        services.AddScoped<IUseCase<SendEmailToOpenOrdersRequest, SendEmailToOpenOrdersResponse>, SendEmailToOpenOrdersUseCase>();
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddScoped<RequestExecutor>();
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<OrderDomainService>();
        return services;
    }
}
