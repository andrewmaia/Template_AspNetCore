using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.UsesCases;


namespace ProjectName.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderUseCase>();
        return services;
    }
}
