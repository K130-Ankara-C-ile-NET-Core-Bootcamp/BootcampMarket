using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class ProductRepository : DapperRepositoryBase, IProductRepository
    {
        public ProductRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
