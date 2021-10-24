using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.Concrete
{
    public class CityRepository : ICityRepository
    {
        public Task DeleteAsync(City entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IAsyncEnumerable<City> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<City> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(City entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(City entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
