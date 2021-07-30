
using System.Collections.Generic;
using System.Linq;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.LegacyModel
{
    public class VoucherLegacy : Entity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string ProductCodes { get; set; }
    }
}