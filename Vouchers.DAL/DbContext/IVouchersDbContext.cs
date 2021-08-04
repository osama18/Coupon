using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.DbContext
{
    public interface IVouchersDbContext
    {
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Gets or sets the Vouchere.
        /// </summary>
        DbSet<Voucher> Vouchers { get; set; }

        /// <summary>
        /// Gets or sets the Product.
        /// </summary>
        DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the Product Deals.
        /// </summary>
        DbSet<Deal> Deals { get; set; }


        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        Task<long?> AddAsync(Entity entity);

        Task AddRangeAsync(IEnumerable<Entity> entities);

        void Update(Entity entity);
    }
}