using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Id)
                .IsRequired();

            builder.HasIndex(x => new { x.Code })
                .HasDatabaseName("IX_Product_UniqueProduct")
                .IsUnique();


        }
    }
}
