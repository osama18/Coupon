using System;
using System.Collections.Generic;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dominos.OLO.Vouchers.Controllers
{
    [ApiController]
    [Route("voucher/")]
    public class VoucherController : ControllerBase
    {
        private VoucherRepository _voucherRepository;

        [HttpGet]
        [Route("")]
        public Voucher[] Get(int count = 0)
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
            return returnVouchers.ToArray();
        }

        [Route("")]
        public Voucher GetVoucherById(Guid id)
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

        [Route("")]
        public Voucher[] GetVouchersByName(string name)
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

            return returnVouchers.ToArray();
        }

        [Route("")]
        public Voucher[] GetVouchersByNameSearch(string search)
        {
            throw new NotImplementedException();
        }

        [Route("")]
        public Voucher GetCheapestVoucherByProductCode(string productCode)
        {
            throw new NotImplementedException();
        }

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
    }
}