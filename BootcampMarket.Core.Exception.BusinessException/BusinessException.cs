using BootcampMarket.Core.Exception.Base;

namespace BootcampMarket.Core.Exception.BusinessException
{
    public class BusinessException : ExceptionBase
    {
        public BusinessException(string message) 
            : base(message)
        {
        }

        public BusinessException(string message, System.Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
