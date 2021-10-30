using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Data.MSSQL.Entity.Base;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class City : EntityBase, IEntity<int>
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public virtual ICollection<District> Districts { get; set; }

        public City()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            Districts = new HashSet<District>();
        }
    }
}
