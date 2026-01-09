using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.Interfaces;
using ProjectName.Application.Repositories;
using ProjectName.Infrastructure.PostgreSQL.Context;
using ProjectName.Infrastructure.PostgreSQL.Repositories;

namespace ProjectName.Infrastructure.PostgreSQL;
public static class DependencyInjection
{
    public static IServiceCollection AddPostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProjectNameDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
