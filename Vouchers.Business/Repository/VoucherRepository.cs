using Newtonsoft.Json;
using System;
using System.IO;
using Vouchers.Business.Models;

namespace Vouchers.Business.Repository
{
    public class VoucherRepository
    {
        internal string DataFilename = $"{AppDomain.CurrentDomain.BaseDirectory}data.json";

        private Voucher[] _vouchers;

        public virtual Voucher[] GetVouchers()
        {
            if (_vouchers == null)
            {
                var text = File.ReadAllText(DataFilename);
                _vouchers = JsonConvert.DeserializeObject<Voucher[]>(text);
            }
            return _vouchers;
        }
    }
}