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
    }
}
