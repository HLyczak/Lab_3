using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SocketLogger : ILogger
    {
        private ClientSocket clientSocket;

        private bool disposed;

        public SocketLogger(string host, int port)
        {
            this.clientSocket = new ClientSocket(host, port);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    this.clientSocket.Dispose();

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        ~SocketLogger()
        {
            this.Dispose(false);
        }

        void ILogger.Log(params string[] messages)
        {
            foreach (string element in messages)
            {
                byte[] requestBytes = Encoding.UTF8.GetBytes(element);
                clientSocket.Send(requestBytes);

                // response:

                byte[] responseBuffer = new byte[1024];
                int responseSize = clientSocket.Receive(responseBuffer);

                string responseText = Encoding.UTF8.GetString(responseBuffer, 0, responseSize); // received message
                Console.WriteLine(responseText);
            }

            clientSocket.Close();
        }
    }
}