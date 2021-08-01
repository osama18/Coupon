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
            
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new DealConfiguration());
            modelBuilder.ApplyConfiguration(new VoucherConfiguration());


            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            
            modelBuilder.Entity<Voucher>().ToTable(nameof(Voucher));
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
            modelBuilder.Entity<Deal>().ToTable(nameof(Deal));
        }

        /// <summary>
        /// Gets or sets the Vouchere.
        /// </summary>
        public DbSet<Voucher> Vouchers { get; set; }

        /// <summary>
        /// Gets or sets the Product.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the Product Deals.
        /// </summary>
        public DbSet<Deal> Deals { get; set; }


        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public void Update(Entity entity) => base.Update(entity);

        public async Task<long?> AddAsync(Entity entity) => (await base.AddAsync(entity))?.Entity?.Id;

        public async Task AddRangeAsync(IEnumerable<Entity> entities) => await base.AddRangeAsync(entities);
    }
}
