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
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Deal)
                .WithMany(x => x.Vouchers)
                .HasForeignKey(x => x.DealId);

            builder.HasIndex(x => new { x.ExternalId })
            .HasDatabaseName("IX_Voucher_ExternalID");
        }
    }
}
