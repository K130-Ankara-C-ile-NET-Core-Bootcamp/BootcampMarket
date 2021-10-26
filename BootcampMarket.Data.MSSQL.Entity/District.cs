using System;
using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class District : IEntity<int>
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int CreatedById { get; set; }

        public int? ModifiedById { get; set; }

        public int? DeletedById { get; set; }

        public virtual City City { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual User DeletedBy { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public District()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
        }
    }
}
