using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vouchers.DAL.DbContext;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IVouchersDbContext vouchersDbContext;
        public ProductRepository(IVouchersDbContext vouchersDbContext) : base(vouchersDbContext)
        {
            this.vouchersDbContext = vouchersDbContext;
        }

        public async Task<Product> GetByCode(string code)
        {
            var result = await vouchersDbContext
              .Products
              .FirstOrDefaultAsync(s => s.Code == code);

            return result;
        }
    }
}
