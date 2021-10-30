using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Business.Operation.Infrastructure
{
    public interface ICountryOperations
    {
        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(int id);

        Task<IEnumerable<Country>> GetAllCountries();

        Task<int> UpdateCountryAsync(Country country);

        Task<int> DeleteCountryAsync(Country country);
    }
}
