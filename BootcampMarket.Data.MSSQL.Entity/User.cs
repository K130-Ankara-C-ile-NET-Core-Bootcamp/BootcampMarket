using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Data.MSSQL.Entity.Base;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class User : EntityBase, IEntity<int>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }
    }
}
