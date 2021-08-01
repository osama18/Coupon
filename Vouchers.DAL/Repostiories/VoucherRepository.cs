using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vouchers.DAL.DbContext;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    internal class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
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
            
            var allVouchers = deals
                .SelectMany(s => s.Vouchers)
                .ToList();
            
            return allVouchers;
        }

        public async Task<ICollection<Voucher>> SearchByName(string name, int take , int skip = 0)
        {
            var deals = await dealRepository
                .SearchByName(name);

            var allVouchers = deals
                .SelectMany(s => s.Vouchers)
                .Skip(skip)
                .Take(take)
                .ToList();

            return allVouchers;
        }

        public async Task<ICollection<Voucher>> RetrievePageIncludeProducts(int take, int skip)
        {
            var result = await vouchersDbContext
                .Set<Voucher>()
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

            if (!product?.Deals?.Any() ?? true)
                return new Voucher();

            var deals = product.Deals;
            double min = double.MaxValue;
            long minId = 0;
            foreach (var deal in deals)
            {
                if (deal.Price < min)
                {
                    min = deal.Price;
                    minId = deal.Id;
                }
            }

            var cheapestDeal = deals.First(s => s.Id == minId);
                
            var voucher = await GetTopVoucherNyDealID(cheapestDeal.Id);

            return voucher;
        }

        private Task<Voucher> GetTopVoucherNyDealID(long id)
        {
            return vouchersDbContext
                .Vouchers
                .Include(v => v.Deal)
                .Include(v => v.Deal.Products)
                .FirstAsync(s => s.DealId == id);
        }
    }
}
