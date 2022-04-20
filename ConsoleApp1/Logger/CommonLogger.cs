using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CommonLogger : ILogger
    {
        private ILogger[] loggers;

        public CommonLogger(ILogger[] loggers)
        {
            this.loggers = loggers;
        }

        void IDisposable.Dispose()
        {
            foreach (ILogger log in loggers)
            {
                log.Dispose();
            }
        }

        void ILogger.Log(params string[] messages)
        {
            DateTime utcTime = DateTime.UtcNow;

            foreach (ILogger logger in loggers)
            {
                logger.Log(messages.Prepend(utcTime.ToString()).ToArray());
            }
        }
    }
}