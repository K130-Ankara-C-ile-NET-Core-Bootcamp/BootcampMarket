using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class UserRepository : DapperRepositoryBase, IUserRepository
    {
        public UserRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
