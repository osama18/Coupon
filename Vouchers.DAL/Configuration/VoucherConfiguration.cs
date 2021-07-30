using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Configuration
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.Price)
                .IsRequired();

            builder.HasIndex(x => new { x.Name })
                .HasDatabaseName("IX_Voucher_UniqueVoucher")
                .IsUnique();
        }
    }
}
