using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class DistrictRepository : DapperRepositoryBase, IDistrictRepository
    {
        public DistrictRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(District entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<District>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<District> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(District entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(District entity)
        {
            throw new NotImplementedException();
        }
    }
}
