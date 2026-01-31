using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjectName.Application.ExternalServices.PostalCode;
using ProjectName.ExternalServices.ViaCEP.Configuration;

namespace ProjectName.ExternalServices.ViaCEP;

public static class DependencyInjection
{
    public static IServiceCollection AddPostalCodeService(
        this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<ViaCepOptions>(configuration.GetSection("ViaCepService"));

        services.AddHttpClient<IPostalCodeService, PostalCodeService>((sp,client) =>
        {
            var options = sp.GetRequiredService<IOptions<ViaCepOptions>>().Value;

            client.BaseAddress = new Uri(options.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        });

        return services;
    }
}
