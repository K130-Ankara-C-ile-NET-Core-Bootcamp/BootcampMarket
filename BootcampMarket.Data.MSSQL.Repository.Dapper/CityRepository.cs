using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CityRepository : ICityRepository
    {
        public Task<int> DeleteAsync(City entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<City>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<City> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> InsertAsync(City entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(City entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
