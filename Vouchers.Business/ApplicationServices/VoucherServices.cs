using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.Business.Models;
using Vouchers.Business.Repository;

namespace Vouchers.Business.ApplicationServices
{
    internal class VoucherServices : IVoucherServices
    {
        private VoucherRepository _voucherRepository;
        internal VoucherRepository Repository
        {
            get
            {
                return _voucherRepository ?? (_voucherRepository = new VoucherRepository());
            }
            set
            {
                _voucherRepository = value;
            }
        }

        public async Task<ICollection<Voucher>> GetAll(int count = 0)
        {
            var vouchers = Repository.GetVouchers();
            if (count == 0)
            {
                count = vouchers.Length;
            }
            var returnVouchers = new List<Voucher>();
            for (var i = 0; i < count; i++)
            {
                returnVouchers.Add(vouchers[i]);
            }
            return vouchers;
        }

        public async Task<Voucher> Get(Guid id)
        {
            var vouchers = Repository.GetVouchers();
            Voucher voucher = null;
            for (var i = 0; i < vouchers.Length; i++)
            {
                if (vouchers[i].Id == id)
                {
                    voucher = vouchers[i];
                }
            }
            return voucher;
        }

        public async Task<ICollection<Voucher>> Get(string name)
        {
            var vouchers = Repository.GetVouchers();
            var returnVouchers = new List<Voucher>();
            for (var i = 0; i < vouchers.Length; i++)
            {
                if (vouchers[i].Name == name)
                {
                    returnVouchers.Add(vouchers[i]);
                }
            }

            return returnVouchers;
        }

        public async Task<ICollection<Voucher>> Search(string searchTerm)
        {
            var vouchers = Repository.GetVouchers();
            var returnVouchers = new List<Voucher>();
            for (var i = 0; i < vouchers.Length; i++)
            {
                if (vouchers[i].Name == searchTerm)
                {
                    returnVouchers.Add(vouchers[i]);
                }
            }

            return returnVouchers;
        }

        public async Task<Voucher> GetCheapest(string productCode)
        {
            return new Voucher();
        }
    }
}
