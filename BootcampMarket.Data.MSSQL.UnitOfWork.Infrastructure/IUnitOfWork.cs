using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.UnitOfWork.Infrastructure
{
    public interface IUnitOfWork : Core.Data.UnitOfWork.Infrastructure.IUnitOfWork
    {
        public ICityRepository CityRepository { get; }

        public ICountryRepository CountryRepository { get; }

        public ICustomerAddressRepository CustomerAddressRepository { get; }

        public ICustomerDetailRepository CustomerDetailRepository { get; }

        public ICustomerRepository CustomerRepository { get; }

        public IDistrictRepository DistrictRepository { get; }

        public IProductCommentRepository ProductCommentRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IUserRepository UserRepository { get; }
    }
}
