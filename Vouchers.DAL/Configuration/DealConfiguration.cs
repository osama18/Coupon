using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Configuration
{
    public class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Price)
                .IsRequired();

                builder.Property(e => e.Name)
                .IsRequired();

            builder.HasIndex(x => new { x.Name })
            .HasDatabaseName("IX_Deal_DealName");
        }
    }
}
