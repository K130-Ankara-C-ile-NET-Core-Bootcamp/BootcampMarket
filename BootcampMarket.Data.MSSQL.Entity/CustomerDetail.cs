using System;
using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Data.MSSQL.Entity.Base;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class CustomerDetail : EntityBase, IEntity
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
