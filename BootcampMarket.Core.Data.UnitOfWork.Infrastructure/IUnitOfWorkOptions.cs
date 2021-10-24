namespace BootcampMarket.Core.Data.UnitOfWork.Infrastructure
{
    public interface IUnitOfWorkOptions
    {
        public string ConnectionString { get; set; }
    }
}
