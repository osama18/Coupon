using Microsoft.Extensions.DependencyInjection;
using Vouchers.Business.ApplicationServices;
using Vouchers.DAL;

namespace Vouchers.Business
{
    public static class Registration
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection collection)
        {
            collection.RegisterDal();
            return collection.AddSingleton<IVoucherServices, VoucherServices>();
        }
    }
}
