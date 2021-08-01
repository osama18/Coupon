using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using Vouchers.Business.Models;

namespace Dominos.OLO.Vouchers.SwaggerExamples
{
    public class VoucherExamples : IExamplesProvider<VoucherDTO>
    {
        public VoucherDTO GetExamples()
        {
            return new VoucherDTO { Id = System.Guid.NewGuid(), Name = "Voucher1", Price = 10, Products = new List<ProductDTO>() { new ProductDTO { Code = "SomeCode"} } };
        }

    }
}