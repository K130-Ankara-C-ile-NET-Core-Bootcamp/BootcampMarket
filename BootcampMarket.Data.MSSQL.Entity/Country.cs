using System;
using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class Country : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int CreatedById { get; set; }

        public int? ModifiedById { get; set; }

        public int? DeletedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual User DeletedBy { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public Country()
        {
            Cities = new HashSet<City>();
            CustomerAddresses = new HashSet<CustomerAddress>();
        }
    }
}
