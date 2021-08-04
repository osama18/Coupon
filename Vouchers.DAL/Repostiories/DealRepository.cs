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
        private readonly IProductRepository productRepository;
        public DealRepository(IVouchersDbContext vouchersDbContext, IProductRepository productRepository) : base(vouchersDbContext)
        {
            this.vouchersDbContext = vouchersDbContext;
            this.productRepository = productRepository;
        }

        public async Task<ICollection<Deal>> RetriveByName(string name)
        {
            var result = await vouchersDbContext
                .Deals
                .Where(s => s.Name == name) // StringComparison.InvariantCultureIgnoreCase
                .ToListAsync();

            return result;
        }

        public async Task<ICollection<Deal>> SearchByName(string name)
        {
            var result = await vouchersDbContext
                .Deals
                .Where(s => s.Name.Contains(name)) //StringComparison.InvariantCultureIgnoreCase
                .ToListAsync();

            return result;
        }

        public async Task<Deal> GetCheapest(long productId)
        {
            var product = await productRepository.RetrieveById(productId);

            if (product == null)
                return null;

            var query = vouchersDbContext.Deals.Where(s => s.Products.Select(t => t.Id).Contains(product.Id));
            var minDealPrice = await query.Select(s => s.Price).MinAsync();
            var minDeal = await query.FirstOrDefaultAsync(s => s.Price == minDealPrice);

            return minDeal;
        }
    }
}
