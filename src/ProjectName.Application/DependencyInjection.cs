using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.UsesCases;
using ProjectName.Domain.Services;


namespace ProjectName.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderUseCase>();
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<OrderDomainService>();
        return services;
    }
}
