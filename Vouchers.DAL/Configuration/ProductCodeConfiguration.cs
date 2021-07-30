using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Configuration
{
    public class ProductCodeConfiguration : IEntityTypeConfiguration<ProductCode>
    {
        public void Configure(EntityTypeBuilder<ProductCode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .IsRequired();

            builder.HasOne(x => x.Voucher)
                .WithMany(x => x.ProductCodes)
                .HasForeignKey(x => x.VoucherId);

            builder.HasIndex(x => new { x.Name })
                .HasDatabaseName("IX_ProductCode_UniqueProductCode")
                .IsUnique();

        }
    }
}
