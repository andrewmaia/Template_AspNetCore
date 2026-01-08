using Microsoft.OpenApi.Models;

namespace ProjectName.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ProjectName API",
                Version = "v1",
                Description = "Documentação automática de ProjectName API"
            });
        });

        return services;
    }
    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        if (app.Environment().IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectName API v1");
                c.RoutePrefix = string.Empty; 
            });
        }

        return app;
    }

    // Helper para pegar o IHostEnvironment no IApplicationBuilder
    private static IHostEnvironment Environment(this IApplicationBuilder app)
    {
        return app.ApplicationServices.GetRequiredService<Microsoft.Extensions.Hosting.IHostEnvironment>();
    }
}

