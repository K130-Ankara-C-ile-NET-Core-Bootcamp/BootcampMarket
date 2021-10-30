using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Data.MSSQL.Entity.Base;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class Product : EntityBase, IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte Discount { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<ProductComment> ProductComments { get; set; }

        public Product()
        {
            ProductComments = new HashSet<ProductComment>();
        }
    }
}
