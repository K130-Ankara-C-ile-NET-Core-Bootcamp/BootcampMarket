using BootcampMarket.Data.MSSQL.Context.EntityFramework.Configurations;
using BootcampMarket.Data.MSSQL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BootcampMarket.Data.MSSQL.Context.EntityFramework
{
    public partial class BootcampMarketDbContext : DbContext
    {
        public BootcampMarketDbContext()
        {
        }

        public BootcampMarketDbContext(DbContextOptions<BootcampMarketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

        public virtual DbSet<District> Districts { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductComment> ProductComments { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerAddressConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerDetailConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCommentConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
