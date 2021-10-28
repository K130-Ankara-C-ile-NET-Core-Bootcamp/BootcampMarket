using BootcampMarket.Mapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampMarket.Mapper.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(
            this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p
                    => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

                cfg.AddProfile<EntityToDTOMapperProfile>();

                cfg.AddProfile<ViewModelToDTOMapperProfile>();
            });

            return services;
        }
    }
}
