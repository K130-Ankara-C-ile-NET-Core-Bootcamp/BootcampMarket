using System;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class CustomerAddress : IEntity<int>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        public string Address { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int CreatedById { get; set; }

        public int? ModifiedById { get; set; }

        public int? DeletedById { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Customer CreatedBy { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Customer DeletedBy { get; set; }

        public virtual District District { get; set; }

        public virtual Customer ModifiedBy { get; set; }
    }
}
