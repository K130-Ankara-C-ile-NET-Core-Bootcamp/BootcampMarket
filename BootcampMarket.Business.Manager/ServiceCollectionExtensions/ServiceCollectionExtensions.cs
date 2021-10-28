using BootcampMarket.Business.Manager.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampMarket.Business.Manager.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessManagers(
            this IServiceCollection services)
        {
            services.AddScoped<ICountryManager, CountryManager>();

            return services;
        }
    }
}
