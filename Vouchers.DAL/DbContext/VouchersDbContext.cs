using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchers.DAL.Configuration;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.DbContext
{
    public class VouchersDbContext : Microsoft.EntityFrameworkCore.DbContext, IVouchersDbContext
    {
        public VouchersDbContext()
        {
        }

        public VouchersDbContext(DbContextOptions<VouchersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new VoucherConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCodeConfiguration());

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            
            modelBuilder.Entity<Voucher>().ToTable(nameof(Voucher));
            modelBuilder.Entity<ProductCode>().ToTable(nameof(ProductCode));
    }

        /// <summary>
        /// Gets or sets the Vouchere.
        /// </summary>
        public DbSet<Voucher> Vouchers { get; set; }

        /// <summary>
        /// Gets or sets the Product Codes.
        /// </summary>
        public DbSet<ProductCode> ProductCodes { get; set; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public void Update(Entity entity) => base.Update(entity);

        public async Task AddAsync(Entity entity) => await base.AddAsync(entity);
    }
}
