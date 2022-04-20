using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ConsoleLogger : WriterLogger, ILogger
    {
        public override void Log(params string[] messages)
        {
            foreach (string element in messages)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}