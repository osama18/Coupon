using System.Threading.Tasks;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetByCode(string code);
    }
}