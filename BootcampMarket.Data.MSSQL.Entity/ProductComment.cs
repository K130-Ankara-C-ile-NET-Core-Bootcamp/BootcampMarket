using System;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class ProductComment : IEntity<int>
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public string Comment { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int CreatedBy { get; set; }

        public int? DeletedBy { get; set; }
    }
}
