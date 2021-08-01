
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> RetrieveById(long id);
        
        Task<IEnumerable<T>> RetrievePage(int take, int skip = 0);
        
        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);

        Task SaveAsync();

        void Update(Entity entity);
    }
}