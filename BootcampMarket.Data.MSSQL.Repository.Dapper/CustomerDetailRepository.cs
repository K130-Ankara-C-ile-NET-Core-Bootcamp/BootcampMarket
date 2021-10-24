using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CustomerDetailRepository : DapperRepositoryBase, ICustomerDetailRepository
    {
        public CustomerDetailRepository(
            IDbConnection connection, 
            IDbTransaction transaction)  
            : base(connection, transaction)
        {
        }

        public Task<IEnumerable<CustomerDetail>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDetail> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(CustomerDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(CustomerDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
