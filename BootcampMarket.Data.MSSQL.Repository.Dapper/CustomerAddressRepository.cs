using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        public Task<int> DeleteAsync(CustomerAddress entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerAddress>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAddress> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(CustomerAddress entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(CustomerAddress entity)
        {
            throw new NotImplementedException();
        }
    }
}
