using System;
using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte Discount { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int CreatedById { get; set; }

        public int? ModifiedById { get; set; }

        public int? DeletedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual User DeletedBy { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<ProductComment> ProductComments { get; set; }

        public Product()
        {
            ProductComments = new HashSet<ProductComment>();
        }
    }
}
