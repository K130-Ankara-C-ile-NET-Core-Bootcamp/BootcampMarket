using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Business.Manager.Model.Country;

namespace BootcampMarket.Business.Manager.Infrastructure
{
    public interface ICountryManager
    {
        Task<CountryDTO> CreateCountryAsync(CreateCountryDTO country);

        Task<CountryDTO> GetCountryByIdAsync(int id);

        Task<IEnumerable<CountryDTO>> GetAllCountries();

        Task UpdateCountryAsync(UpdateCountryDTO country);
        Task DeleteCountryByIdAsync(int id);
    }
}
