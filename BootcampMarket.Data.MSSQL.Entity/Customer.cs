using System;
using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool IsActive { get; set; }

        public virtual CustomerDetail CustomerDetail { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddressCreatedBy { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddressCustomers { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddressDeletedBy { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddressModifiedBy { get; set; }

        public virtual ICollection<ProductComment> ProductCommentCreatedBy { get; set; }

        public virtual ICollection<ProductComment> ProductCommentCustomers { get; set; }

        public virtual ICollection<ProductComment> ProductCommentDeletedBy { get; set; }

        public Customer()
        {
            CustomerAddressCreatedBy = new HashSet<CustomerAddress>();
            CustomerAddressCustomers = new HashSet<CustomerAddress>();
            CustomerAddressDeletedBy = new HashSet<CustomerAddress>();
            CustomerAddressModifiedBy = new HashSet<CustomerAddress>();
            ProductCommentCreatedBy = new HashSet<ProductComment>();
            ProductCommentCustomers = new HashSet<ProductComment>();
            ProductCommentDeletedBy = new HashSet<ProductComment>();
        }
    }
}
