using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class ProductCommentRepository : DapperRepositoryBase, IProductCommentRepository
    {
        public ProductCommentRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(ProductComment entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductComment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductComment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(ProductComment entity)
        {
            throw new NotImplementedException();
        }
    }
}
