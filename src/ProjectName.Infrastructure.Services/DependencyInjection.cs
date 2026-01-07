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
        services.AddScoped<IMessageBus, AzureServiceBusMessageBus>();
        services.AddScoped<IFileStorage, AzureBlobStorage>();

        // outros serviços de infra

        return services;
    }
}