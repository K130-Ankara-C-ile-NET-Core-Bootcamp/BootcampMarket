using System;

namespace BootcampMarket.Core.Data.UnitOfWork.Concrete
{
    public abstract class UnitOfWorkBase : IDisposable
    {
        private bool _disposed;

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
