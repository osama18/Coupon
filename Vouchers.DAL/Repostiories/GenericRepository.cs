using Vouchers.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.DAL.DbContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Vouchers.DAL.Repostiories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly IVouchersDbContext vouchersDbContext;

        protected GenericRepository(IVouchersDbContext vouchersDbContext)
        {
            this.vouchersDbContext = vouchersDbContext;
        }

        public async Task InsertAsync(T entity) => await vouchersDbContext.AddAsync(entity);

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await vouchersDbContext.AddRangeAsync(entities);
        }

        public void Update(Entity entity) => vouchersDbContext.Update(entity);
        
        public async Task SaveAsync() => await vouchersDbContext.SaveChangesAsync();

        public async Task<IEnumerable<T>> RetrievePage(int take , int skip = 0)
        {
            return await vouchersDbContext.Set<T>().Take(take).Skip(skip).ToListAsync();
        }

        public async Task<T> RetrieveById(long id)
        {
            return await vouchersDbContext.Set<T>().FindAsync(id);
        }

    }
}