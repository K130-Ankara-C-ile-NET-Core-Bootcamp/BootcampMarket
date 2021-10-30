using BootcampMarket.Data.MSSQL.Entity;
using FluentValidation;

namespace BootcampMarket.Data.MSSQL.Validation
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(country => country.Name)
               .NotNull()
               .NotEmpty()
               .MaximumLength(100);
        }
    }
}
