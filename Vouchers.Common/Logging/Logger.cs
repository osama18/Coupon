using System;
using System.Threading.Tasks;

namespace Vouchers.Common.Logging
{
    public class Logger  : ILogger
    {
        public Task LogErrorAsync(ErrorLevel ErrorLevel, Exception ex, string LogType)
        {
            return Task.FromResult(0);
        }
    }
}
