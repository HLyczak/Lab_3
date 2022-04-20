using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileLogger : WriterLogger, ILogger
    {
        private string path;
        private bool disposed = false;

        private FileStream stream;

        public FileLogger(string path)
        {
            this.path = path;
        }

        public override void Log(params string[] messages)
        {
            if (!File.Exists(path))
            {
                using (stream = File.Create(path))
                {
                    using (writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        base.Log(messages);
                    }
                }
            }
            else
            {
                using (stream = new FileStream(path, FileMode.Append))
                {
                    using (writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        base.Log(messages);
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    this.stream.Dispose();

                this.disposed = true;
            }
        }

        public override void Dispose()
        {
            this.Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        ~FileLogger()
        {
            this.Dispose(false);
        }
    }
}