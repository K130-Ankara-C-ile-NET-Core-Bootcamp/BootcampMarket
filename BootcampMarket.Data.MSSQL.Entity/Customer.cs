using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Data.MSSQL.Entity.Base;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class Customer : EntityBase, IEntity<int>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }

        public bool IsActive { get; set; }

        public virtual CustomerDetail CustomerDetail { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddressCustomers { get; set; }

        public virtual ICollection<ProductComment> ProductCommentCustomers { get; set; }

        public Customer()
        {
            CustomerAddressCustomers = new HashSet<CustomerAddress>();
            ProductCommentCustomers = new HashSet<ProductComment>();

            // This should be true for new customers
            IsActive = true;
        }
    }
}
