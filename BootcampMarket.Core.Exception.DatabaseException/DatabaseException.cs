using BootcampMarket.Core.Exception.Base;

namespace BootcampMarket.Core.Exception.DatabaseException
{
    public class DatabaseException : ExceptionBase
    {
        public DatabaseException(string message)
            : base(message)
        {
        }

        public DatabaseException(string message, System.Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
