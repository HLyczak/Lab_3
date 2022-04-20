using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            ILogger[] loggers = new ILogger[]
            {
                new ConsoleLogger(),
                new FileLogger("filelogger.txt"),
                new SocketLogger("google.com", 80)
            };

            using ILogger logger = new CommonLogger(loggers);
            logger.Log("Example message 1 ...");
            logger.Log("Example message 2 ...");
            logger.Log("Example message 3 ...", "value 1", "value 2", "value 3");
        }
    }
}