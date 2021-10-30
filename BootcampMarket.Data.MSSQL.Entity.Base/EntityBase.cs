using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Data.MSSQL.Entity.Base
{
    public class EntityBase : IEntity
    {
        public bool Status { get; set; }

        public EntityBase()
        {
            Status = true;
        }
    }
}
