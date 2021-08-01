using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ICollection<Deal>> RetriveByName(string name)
        {
            var result = await vouchersDbContext
                .Deals
                .Where(s => s.Name == name) // StringComparison.InvariantCultureIgnoreCase
                .Include(s => s.Vouchers)
                .Include(s => s.Products)
                .ToListAsync();

            return result;
        }

        public async Task<ICollection<Deal>> SearchByName(string name)
        {
            var result = await vouchersDbContext
                .Deals
                .Where(s => s.Name.Contains(name)) //StringComparison.InvariantCultureIgnoreCase
                .Include(s => s.Vouchers)
                .Include(s => s.Products)
                .ToListAsync();

            return result;
        }
    }
}
