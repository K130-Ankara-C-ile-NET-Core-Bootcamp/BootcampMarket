using BootcampMarket.Data.MSSQL.UnitOfWork.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampMarket.Data.MSSQL.UnitOfWork.Dapper.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperUnitOfWork(
            this IServiceCollection services,
            DapperUnitOfWorkOptions options)
        {
            services.AddScoped<IUnitOfWork>(
                provider => new DapperUnitOfWork(options));

            return services;
        }
    }
}
