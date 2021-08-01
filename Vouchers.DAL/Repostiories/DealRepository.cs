using Vouchers.DAL.DbContext;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    internal class DealRepository : GenericRepository<Deal>, IDealRepository
    {
        private readonly IVouchersDbContext vouchersDbContext;
        public DealRepository(IVouchersDbContext vouchersDbContext) : base(vouchersDbContext)
        {
            this.vouchersDbContext = vouchersDbContext;
        }
    }
}
