using BootcampMarket.Data.MSSQL.UnitOfWork.Dapper;
using BootcampMarket.Data.MSSQL.UnitOfWork.Dapper.ServiceCollectionExtensions;
using BootcampMarket.Data.MSSQL.UnitOfWork.EntityFramework;
using BootcampMarket.Data.MSSQL.UnitOfWork.EntityFramework.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BootcampMarket.Service.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BootcampMarket.Service.API", Version = "v1" });
            });

            //services.AddDapperUnitOfWork(new DapperUnitOfWorkOptions
            //{
            //    ConnectionString = "Server=.;Database=BootcampMarketDb;Trusted_Connection=True;"
            //});

            services.AddEntityFrameworkUnitOfWork(new EntityFrameworkUnitOfWorkOptions
            {
                ConnectionString = "Server=.;Database=BootcampMarketDb;Trusted_Connection=True;"
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BootcampMarket.Service.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
