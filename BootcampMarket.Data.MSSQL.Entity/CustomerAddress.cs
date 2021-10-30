using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Data.MSSQL.Entity.Base;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class CustomerAddress : EntityBase, IEntity<int>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        public string Address { get; set; }
        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual District District { get; set; }
    }
}
