using System;
using System.Threading.Tasks;

namespace Vouchers.Common.Logging
{
    public interface ILogger 
    {
        public Task LogErrorAsync(ErrorLevel ErrorLevel, Exception ex, string LogType);
    }
}
