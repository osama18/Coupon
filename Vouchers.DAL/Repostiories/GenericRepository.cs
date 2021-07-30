using Vouchers.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.DAL.DbContext;

namespace Vouchers.DAL.Repostiories
{
    internal abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly IVouchersDbContext vouchersDbContext;

        protected GenericRepository(IVouchersDbContext vouchersDbContext)
        {
            this.vouchersDbContext = vouchersDbContext;
        }

        public async Task InsertAsync(T entity) => await vouchersDbContext.AddAsync(entity);

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                await vouchersDbContext.AddAsync(entity);
        }

        public void Update(Entity entity) => vouchersDbContext.Update(entity);
        
        public async Task SaveAsync() => await vouchersDbContext.SaveChangesAsync();
    }
}