using Microsoft.Extensions.DependencyInjection;
using Vouchers.Business.ApplicationServices;

namespace Vouchers.Business
{
    public static class Registration
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection collection)
        {
            return collection.AddSingleton<IVoucherServices, VoucherServices>();
        }
    }
}
