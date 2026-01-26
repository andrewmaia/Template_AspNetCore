using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.Interfaces;
using ProjectName.Infrastructure.Services.Messaging;
using ProjectName.Infrastructure.Services.Storage;

namespace ProjectName.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        //Message Bus
        services.AddScoped<IMessageBus, AzureServiceBusMessageBus>();
        // File storage
        services.Configure<AzureBlobStorageOptions>(configuration.GetSection("AzureBlobStorage"));
        services.AddScoped<IFileStorage, AzureBlobStorage>();


        // Observability
        services.AddSingleton<IObservability, AppInsightsObservability>();

        return services;
    }
}