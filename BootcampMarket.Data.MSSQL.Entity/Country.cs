using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Data.MSSQL.Entity.Base;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class Country : EntityBase, IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public Country()
        {
            Cities = new HashSet<City>();
            CustomerAddresses = new HashSet<CustomerAddress>();
        }
    }
}
