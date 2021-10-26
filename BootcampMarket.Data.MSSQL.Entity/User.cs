using System;
using System.Collections.Generic;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Data.MSSQL.Entity
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }

        public string UserName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? CreatedById { get; set; }

        public int? ModifiedById { get; set; }

        public int? DeletedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual User DeletedBy { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<City> CityCreatedBy { get; set; }

        public virtual ICollection<City> CityDeletedBy { get; set; }

        public virtual ICollection<City> CityModifiedBy { get; set; }

        public virtual ICollection<Country> CountryCreatedBy { get; set; }

        public virtual ICollection<Country> CountryDeletedBy { get; set; }

        public virtual ICollection<Country> CountryModifiedBy { get; set; }

        public virtual ICollection<District> DistrictCreatedBy { get; set; }

        public virtual ICollection<District> DistrictDeletedBy { get; set; }

        public virtual ICollection<District> DistrictModifiedBy { get; set; }

        public virtual ICollection<User> InverseCreatedBy { get; set; }

        public virtual ICollection<User> InverseDeletedBy { get; set; }

        public virtual ICollection<User> InverseModifiedBy { get; set; }

        public virtual ICollection<Product> ProductCreatedBy { get; set; }

        public virtual ICollection<Product> ProductDeletedBy { get; set; }

        public virtual ICollection<Product> ProductModifiedBy { get; set; }

        public User()
        {
            CityCreatedBy = new HashSet<City>();
            CityDeletedBy = new HashSet<City>();
            CityModifiedBy = new HashSet<City>();
            CountryCreatedBy = new HashSet<Country>();
            CountryDeletedBy = new HashSet<Country>();
            CountryModifiedBy = new HashSet<Country>();
            DistrictCreatedBy = new HashSet<District>();
            DistrictDeletedBy = new HashSet<District>();
            DistrictModifiedBy = new HashSet<District>();
            InverseCreatedBy = new HashSet<User>();
            InverseDeletedBy = new HashSet<User>();
            InverseModifiedBy = new HashSet<User>();
            ProductCreatedBy = new HashSet<Product>();
            ProductDeletedBy = new HashSet<Product>();
            ProductModifiedBy = new HashSet<Product>();
        }
    }
}
