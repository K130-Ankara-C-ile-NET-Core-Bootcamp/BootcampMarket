using BootcampMarket.Data.MSSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampMarket.Data.MSSQL.Context.EntityFramework.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        }
    }
}
