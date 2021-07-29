using Dominos.OLO.Vouchers.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace Dominos.OLO.Vouchers.SwaggerExamples
{
    public class VoucherExamples : IExamplesProvider<Voucher>
    {
        public Voucher GetExamples()
        {
            return new Voucher { Id = System.Guid.NewGuid(), Name = "Voucher1", Price = 10, ProductCodes = "somecode" };
        }

    }
}