using BootcampMarket.Data.MSSQL.Entity;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

namespace BootcampMarket.Data.MSSQL.Validation.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddMSSQLValidators(
            this IMvcBuilder mvcBuilder, 
            IServiceCollection services)
        {
            services.AddTransient<IValidator<Country>, CountryValidator>();

            mvcBuilder.AddFluentValidation();

            return mvcBuilder;
        }
    }
}
