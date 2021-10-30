using BootcampMarket.Data.MSSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampMarket.Data.MSSQL.Context.EntityFramework.Configurations
{
    internal class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddress");

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.HasOne(d => d.City)
                .WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerAddress_City");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerAddress_Country");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.CustomerAddressCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerAddress_Customer");

            builder.HasOne(d => d.District)
                .WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerAddress_District");
        }
    }
}
