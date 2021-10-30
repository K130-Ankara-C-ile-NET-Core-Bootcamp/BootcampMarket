using System;
using BootcampMarket.Data.MSSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampMarket.Data.MSSQL.Context.EntityFramework.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(32)
                .IsFixedLength(true);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
