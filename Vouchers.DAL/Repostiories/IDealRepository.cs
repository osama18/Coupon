using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    public interface IDealRepository : IGenericRepository<Deal>
    {
        Task<ICollection<Deal>> RetriveByName(string name);
        Task<ICollection<Deal>> SearchByName(string name);

        Task<Deal> GetCheapest(long productId);
    }
}