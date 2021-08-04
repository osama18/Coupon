using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vouchers.DAL.DbContext;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
    {
        private readonly IDealRepository dealRepository;
        private readonly IProductRepository productRepository;
        private readonly IVouchersDbContext vouchersDbContext;
        public VoucherRepository(IVouchersDbContext vouchersDbContext,
            IDealRepository dealRepository,
            IProductRepository productRepository) : base(vouchersDbContext)
        {
            this.vouchersDbContext = vouchersDbContext;
            this.dealRepository = dealRepository;
            this.productRepository = productRepository;
        }

        public async Task<Voucher> RetrieveByExternalId(Guid id)
        {
            var result = await vouchersDbContext
                .Set<Voucher>()
                .Include(s => s.Deal)
                .Include(s => s.Deal.Products)
                .FirstOrDefaultAsync(s => s.ExternalId == id);

            return result;
        }

        public async Task<ICollection<Voucher>> RetrieveByName(string name)
        {
            var deals = await dealRepository.
                RetriveByName(name);

            if (!deals?.Any() ?? true)
                return null;

            var dealsIds = deals.Select(s => s.Id);

            var allVouchers = await vouchersDbContext
                .Vouchers
                .Include(s => s.Deal)
                .Include(s => s.Deal.Products)
                .Where(s => dealsIds.Contains(s.DealId))
                .ToListAsync();
            
            return allVouchers;
        }

        public async Task<ICollection<Voucher>> SearchByName(string name, int take , int skip = 0)
        {
            var deals = await dealRepository
                .SearchByName(name);

            if (!deals?.Any() ?? true)
                return null;

            var dealsIds = deals.Select(s => s.Id);

            var allVouchers = await vouchersDbContext
                .Vouchers
                .Include(s => s.Deal)
                .Include(s => s.Deal.Products)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return allVouchers;
        }

        public async Task<ICollection<Voucher>> RetrievePageIncludeProducts(int take, int skip)
        {
            var result = await vouchersDbContext
                .Vouchers
                .Include(s => s.Deal)
                .Include(s => s.Deal.Products)
                .Take(take)
                .Skip(skip)
                .ToListAsync();

            return result;
        }

        public async Task<Voucher> GetCheapest(string productCode)
        {

            var product = await productRepository.GetByCode(productCode);

            if (product == null)
                return null;

            var deal = await dealRepository.GetCheapest(product.Id);

            return await vouchersDbContext
                .Vouchers
                .Include(s => s.Deal)
                .Include(s => s.Deal.Products)
                .FirstOrDefaultAsync(s => s.DealId == deal.Id);
        }

    }
}
