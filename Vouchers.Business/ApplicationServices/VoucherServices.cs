using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.Business.Models;
using System.Linq;
using Vouchers.DAL.Repostiories;

namespace Vouchers.Business.ApplicationServices
{
    internal class VoucherServices : IVoucherServices
    {
        private readonly IVoucherRepository voucherRepository;
        private readonly IMapper mapper;
        public VoucherServices(IVoucherRepository voucherRepository, IMapper mapper)
        {
            this.voucherRepository = voucherRepository;
            this.mapper = mapper;
        }

        public async Task<ICollection<VoucherDTO>> GetAll(int take, int skip = 0)
        {
            var vouchers = await voucherRepository.RetrievePageIncludeProducts(take, skip);
            var result = vouchers?.Select(mapper.Map<VoucherDTO>).ToList();
            return result;
        }

        public async Task<VoucherDTO> Get(Guid id)
        {
            var voucher = await voucherRepository.RetrieveByExternalId(id);
            return mapper.Map <VoucherDTO>(voucher);
        }

        public async Task<ICollection<VoucherDTO>> Get(string name)
        {
            var vouchers = await voucherRepository.RetrieveByName(name);
            var result = vouchers?.Select(mapper.Map<VoucherDTO>).ToList();
            return result;
        }

        public async Task<ICollection<VoucherDTO>> Search(string searchTerm, int take , int skip = 0)
        {
            var vouchers = await voucherRepository.SearchByName(searchTerm, take, skip);
            var result = vouchers?.Select(mapper.Map<VoucherDTO>).ToList();
            return result;
        }

        public async Task<VoucherDTO> GetCheapest(string productCode)
        {
            var voucher = await voucherRepository.GetCheapest(productCode);
            return mapper.Map<VoucherDTO>(voucher);
        }
    }
}
