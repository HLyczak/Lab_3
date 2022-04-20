using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class WriterLogger : ILogger
    {
        protected TextWriter writer;

        public virtual void Log(params string[] messages)
        {
            foreach (string element in messages)
            {
                writer.Write($" {element}");
            }
            writer.Write(Environment.NewLine);

            writer.Flush();
        }

        public abstract void Dispose();
    }
}