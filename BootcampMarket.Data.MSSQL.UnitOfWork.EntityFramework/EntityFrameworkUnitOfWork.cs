using BootcampMarket.Core.Data.UnitOfWork.Concrete;
using BootcampMarket.Data.MSSQL.Context.EntityFramework;
using BootcampMarket.Data.MSSQL.Repository.EntityFramework;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.UnitOfWork.EntityFramework
{
    public class EntityFrameworkUnitOfWork : UnitOfWorkBase
    {
        public BootcampMarketDbContext Context { get; private set; }

        #region Public Properties
        public ICityRepository CityRepository
            => _cityRepository ??= new CityRepository(Context);

        public ICountryRepository CountryRepository
           => _countryRepository ??= new CountryRepository(Context);

        public ICustomerAddressRepository CustomerAddressRepository
           => _customerAddressRepository ??= new CustomerAddressRepository(Context);

        public ICustomerDetailRepository CustomerDetailRepository
           => _customerDetailRepository ??= new CustomerDetailRepository(Context);

        public ICustomerRepository CustomerRepository
           => _customerRepository ??= new CustomerRepository(Context);

        public IDistrictRepository DistrictRepository
           => _districtRepository ??= new DistrictRepository(Context);

        public IProductCommentRepository ProductCommentRepository
           => _productCommentRepository ??= new ProductCommentRepository(Context);

        public IProductRepository ProductRepository
           => _productRepository ??= new ProductRepository(Context);

        public IUserRepository UserRepository
           => _userRepository ??= new UserRepository(Context);
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

        public EntityFrameworkUnitOfWork(BootcampMarketDbContext context)
        {
            Context = context;
        }

        public override void Commit()
        {
            Context.SaveChanges();
        }

        public override void Rollback()
        {
            Context.ChangeTracker.Clear();
        }

        protected override void FreeResources(bool disposing)
        {
            if (disposing && Context != null)
            {
                Context.Dispose();
            }

            Context = null;
        }
    }
}
