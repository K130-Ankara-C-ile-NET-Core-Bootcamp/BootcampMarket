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

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.CityCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_User");

                entity.HasOne(d => d.DeletedBy)
                    .WithMany(p => p.CityDeletedBy)
                    .HasForeignKey(d => d.DeletedById)
                    .HasConstraintName("FK_City_User2");

                entity.HasOne(d => d.ModifiedBy)
                    .WithMany(p => p.CityModifiedBy)
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_City_User1");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.CountryCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_User");

                entity.HasOne(d => d.DeletedBy)
                    .WithMany(p => p.CountryDeletedBy)
                    .HasForeignKey(d => d.DeletedById)
                    .HasConstraintName("FK_Country_User2");

                entity.HasOne(d => d.ModifiedBy)
                    .WithMany(p => p.CountryModifiedBy)
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Country_User1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.ToTable("CustomerAddress");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Country");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.CustomerAddressCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Customer1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddressCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Customer");

                entity.HasOne(d => d.DeletedBy)
                    .WithMany(p => p.CustomerAddressDeletedBy)
                    .HasForeignKey(d => d.DeletedById)
                    .HasConstraintName("FK_CustomerAddress_Customer3");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_District");

                entity.HasOne(d => d.ModifiedBy)
                    .WithMany(p => p.CustomerAddressModifiedBy)
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_CustomerAddress_Customer2");
            });

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_CustomerDetail_1");

                entity.ToTable("CustomerDetail");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.CustomerDetail)
                    .HasForeignKey<CustomerDetail>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerDetail_Customer1");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_City");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.DistrictCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_User");

                entity.HasOne(d => d.DeletedBy)
                    .WithMany(p => p.DistrictDeletedBy)
                    .HasForeignKey(d => d.DeletedById)
                    .HasConstraintName("FK_District_User2");

                entity.HasOne(d => d.ModifiedBy)
                    .WithMany(p => p.DistrictModifiedBy)
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_District_User1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProductCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_User2");

                entity.HasOne(d => d.DeletedBy)
                    .WithMany(p => p.ProductDeletedBy)
                    .HasForeignKey(d => d.DeletedById)
                    .HasConstraintName("FK_Product_User1");

                entity.HasOne(d => d.ModifiedBy)
                    .WithMany(p => p.ProductModifiedBy)
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_Product_User");
            });

            modelBuilder.Entity<ProductComment>(entity =>
            {
                entity.ToTable("ProductComment");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProductCommentCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductComment_Customer1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductCommentCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductComment_Customer");

                entity.HasOne(d => d.DeletedBy)
                    .WithMany(p => p.ProductCommentDeletedBy)
                    .HasForeignKey(d => d.DeletedById)
                    .HasConstraintName("FK_ProductComment_Customer2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductComments)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductComment_Product");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.InverseCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_User_User");

                entity.HasOne(d => d.DeletedBy)
                    .WithMany(p => p.InverseDeletedBy)
                    .HasForeignKey(d => d.DeletedById)
                    .HasConstraintName("FK_User_User2");

                entity.HasOne(d => d.ModifiedBy)
                    .WithMany(p => p.InverseModifiedBy)
                    .HasForeignKey(d => d.ModifiedById)
                    .HasConstraintName("FK_User_User1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
