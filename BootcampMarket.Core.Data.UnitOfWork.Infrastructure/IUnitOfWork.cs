namespace BootcampMarket.Core.Data.UnitOfWork.Infrastructure
{
    public interface IUnitOfWork
    {
        public void Commit();

        public void Rollback();
    }
}
