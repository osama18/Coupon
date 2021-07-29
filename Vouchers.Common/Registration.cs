using Microsoft.Extensions.DependencyInjection;
using Vouchers.Common.Logging;

namespace Vouchers.Common
{
    public static class Registration
    {
        public static IServiceCollection RegisterCommon(this IServiceCollection collection)
        {
            return collection.AddSingleton<ILogger, Logger>();
        }
    }
}
