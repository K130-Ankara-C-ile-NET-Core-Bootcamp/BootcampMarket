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

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public int? DeletedBy { get; set; }
    }
}
