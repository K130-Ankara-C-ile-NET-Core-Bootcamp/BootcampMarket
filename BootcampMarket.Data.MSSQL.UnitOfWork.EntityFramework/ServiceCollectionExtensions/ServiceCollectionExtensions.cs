﻿using BootcampMarket.Core.Data.UnitOfWork.Concrete;
using BootcampMarket.Data.MSSQL.Context.EntityFramework;
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
            services.AddDbContext<BootcampMarketDbContext>(x=>
                x.UseSqlServer(options.ConnectionString)
            );

            services.AddScoped<EntityFrameworkUnitOfWork>();

            return services;
        }
    }
}
