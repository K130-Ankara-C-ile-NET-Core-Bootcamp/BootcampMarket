using BootcampMarket.Data.MSSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampMarket.Data.MSSQL.Context.EntityFramework.Configurations
{
    internal class CustomerDetailConfiguration : IEntityTypeConfiguration<CustomerDetail>
    {
        public void Configure(EntityTypeBuilder<CustomerDetail> builder)
        {
            builder.ToTable("CustomerDetail");

            builder.Property(e => e.CustomerId).ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.HasOne(d => d.Customer)
                .WithOne(p => p.CustomerDetail)
                .HasForeignKey<CustomerDetail>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerDetail_Customer1");

            builder.HasKey(e => e.CustomerId)
                   .HasName("PK_CustomerDetail_1");
        }
    }
}
