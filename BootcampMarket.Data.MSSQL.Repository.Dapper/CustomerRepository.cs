﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CustomerRepository : DapperRepositoryBase, ICustomerRepository
    {
        public CustomerRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(Customer entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE Customer SET IsActive = 0
                        WHERE Id = @Id AND IsActive != 0";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            var sql = @"SELECT * FROM Customer WHERE IsActive != 0";

            return Connection.QueryAsync<Customer>(sql, transaction: Transaction);
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Customer WHERE ID = @Id AND IsActive != 0";

            return Connection.QueryFirstOrDefaultAsync<Customer>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<int> InsertAsync(Customer entity)
        {
            var sql = @"INSERT INTO Customer (Email, Password)
                            VALUES(@Email, @Password)
                        SELECT SCOPE_IDENTITY()";

            return Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);
        }

        public Task<int> UpdateAsync(Customer entity)
        {
            var sql = @"UPDATE Customer SET
                        Name = @Name,
                        Password = @Password,
                        ModifyDate = GETDATE(),
                        WHERE ID = @Id AND IsActive != 0";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
