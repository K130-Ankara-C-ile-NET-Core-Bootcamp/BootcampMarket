using System;
using System.Data;
using BootcampMarket.Core.Data.UnitOfWork.Infrastructure;

namespace BootcampMarket.Core.Data.UnitOfWork.Concrete
{
    public class UnitOfWorkBase : IUnitOfWork, IDisposable
    {
        protected IUnitOfWorkOptions Options { get; }

        protected IDbConnection Connection { get; set; }

        protected IDbTransaction Transaction { get; set; }

        private bool _disposed;

        public UnitOfWorkBase(IUnitOfWorkOptions options)
        {
            Options = options;
        }

        // Apply changes to database
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

        // Revert database changes
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

            _disposed = true;
        }
    }
}
