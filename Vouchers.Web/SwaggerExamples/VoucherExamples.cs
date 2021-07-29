using Swashbuckle.AspNetCore.Filters;
using Vouchers.Business.Models;

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