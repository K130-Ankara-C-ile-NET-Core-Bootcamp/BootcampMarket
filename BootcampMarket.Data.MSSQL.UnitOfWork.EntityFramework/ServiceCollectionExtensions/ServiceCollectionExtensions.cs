using BootcampMarket.Data.MSSQL.Context.EntityFramework;
using BootcampMarket.Data.MSSQL.UnitOfWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampMarket.Data.MSSQL.UnitOfWork.EntityFramework.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkUnitOfWork(
           this IServiceCollection services,
           EntityFrameworkUnitOfWorkOptions options)
        {
            services.AddDbContext<BootcampMarketDbContext>(x =>
                x.UseSqlServer(options.ConnectionString,
                r => r.MigrationsAssembly(options.MigrationAssembly)
                )
            );

            services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork>();

            return services;
        }
    }
}
