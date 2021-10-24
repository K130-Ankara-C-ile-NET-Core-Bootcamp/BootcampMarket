using System;
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
    }
}
