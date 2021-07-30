using Vouchers.DAL.DbContext;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    internal class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
    {
        private readonly IVouchersDbContext vouchersDbContext;
        public VoucherRepository(IVouchersDbContext vouchersDbContext) : base(vouchersDbContext)
        {
            this.vouchersDbContext = vouchersDbContext;
        }
    }
}
