using System;
using System.Data;
using BootcampMarket.Core.Data.UnitOfWork.Infrastructure;

namespace BootcampMarket.Core.Data.UnitOfWork.Concrete
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private bool _disposed;

        // Apply changes to database
        public abstract void Commit();

        // Revert database changes
        public abstract void Rollback();

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            FreeResources(disposing);

            _disposed = true;
        }

        protected abstract void FreeResources(bool disposing);
    }
}
