using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Data.MSSQL.Entity.Base;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class District : EntityBase, IEntity<int>
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public District()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
        }
    }
}
