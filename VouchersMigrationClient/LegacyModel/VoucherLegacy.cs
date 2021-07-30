

using System;

namespace Vouchers.LegacyModel
{
    public class VoucherLegacy 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public string ProductCodes { get; set; }
    }
}