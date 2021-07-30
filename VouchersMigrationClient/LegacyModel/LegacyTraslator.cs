using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vouchers.DAL.Entities;

namespace Vouchers.LegacyModel
{
    internal static class LegacyTraslator
    {
        public static IEnumerable<ProductCode> TranslateToProductCodes(this string productCodesString , char delimitar = ',')
        {
            return productCodesString.Split(',').Select(s => new ProductCode { Name = s, Id = Guid.NewGuid()});
        }

        public static Voucher VoucherLegacyToVoucher(VoucherLegacy voucherLegacy)
        {
            return new Voucher {
                Id = voucherLegacy.Id,
                Name = voucherLegacy.Name,
                Price = voucherLegacy.Price,
                ProductCodes = voucherLegacy.ProductCodes?.TranslateToProductCodes().ToList()
            };
        }
    }
}
