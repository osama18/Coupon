using Microsoft.Extensions.DependencyInjection;
using Vouchers.Common.Logging;
using Vouchers.Common.Settings;

namespace Vouchers.Common
{
    public static class Registration
    {
        public static IServiceCollection RegisterCommon(this IServiceCollection collection)
        {
            collection.AddSingleton<ISettingProvider, ConfigSettingsProvider>(); 
            return collection.AddSingleton<ILogger, Logger>();
        }
    }
}
