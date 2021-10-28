using System;
using System.Data;
using System.Data.SqlClient;
using BootcampMarket.Core.Data.UnitOfWork.Concrete;
using BootcampMarket.Core.Data.UnitOfWork.Infrastructure;
using BootcampMarket.Data.MSSQL.Repository.Dapper;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.UnitOfWork.Dapper
{
    public class DapperUnitOfWork : UnitOfWorkBase, Infrastructure.IUnitOfWork
    {
        #region Public Properties
        public ICityRepository CityRepository
            => _cityRepository ??= new CityRepository(Connection, Transaction);

        public ICountryRepository CountryRepository
            => _countryRepository ??= new CountryRepository(Connection, Transaction);

        public ICustomerAddressRepository CustomerAddressRepository
            => _customerAddressRepository ??= new CustomerAddressRepository(Connection, Transaction);

        public ICustomerDetailRepository CustomerDetailRepository
            => _customerDetailRepository ??= new CustomerDetailRepository(Connection, Transaction);

        public ICustomerRepository CustomerRepository
            => _customerRepository ??= new CustomerRepository(Connection, Transaction);

        public IDistrictRepository DistrictRepository
            => _districtRepository ??= new DistrictRepository(Connection, Transaction);

        public IProductCommentRepository ProductCommentRepository
            => _productCommentRepository ??= new ProductCommentRepository(Connection, Transaction);

        public IProductRepository ProductRepository
            => _productRepository ??= new ProductRepository(Connection, Transaction);

        public IUserRepository UserRepository
            => _userRepository ??= new UserRepository(Connection, Transaction);
        #endregion

        #region Private Fields
        private ICityRepository _cityRepository;
        private ICountryRepository _countryRepository;
        private ICustomerAddressRepository _customerAddressRepository;
        private ICustomerDetailRepository _customerDetailRepository;
        private ICustomerRepository _customerRepository;
        private IDistrictRepository _districtRepository;
        private IProductCommentRepository _productCommentRepository;
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        #endregion

        protected IDbConnection Connection { get; set; }

        protected IDbTransaction Transaction { get; set; }

        public DapperUnitOfWork(IUnitOfWorkOptions options)
        {
            Connection = new SqlConnection(options.ConnectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch (Exception)
            {
                Transaction.Rollback();

                throw;
            }
        }

        public void Rollback()
        {
            try
            {
                Transaction.Rollback();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void FreeResources(bool disposing)
        {
            if (disposing)
            {
                if (Transaction != null)
                {
                    if (Connection != null)
                    {
                        if (Connection.State != ConnectionState.Closed)
                        {
                            Connection.Close();
                        }

                        Connection.Dispose();
                    }

                    Transaction.Dispose();
                }
            }

            Transaction = null;
            Connection = null;
        }
    }
}
