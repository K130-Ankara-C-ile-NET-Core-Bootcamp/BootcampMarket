using BootcampMarket.Business.Operation.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampMarket.Business.Operation.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessOperations(
            this IServiceCollection services)
        {
            services.AddScoped<ICountryOperations, CountryOperations>();

            return services;
        }
    }
}
