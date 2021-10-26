using System;

namespace BootcampMarket.Core.Data.UnitOfWork.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        public void Commit();

        public void Rollback();
    }
}
