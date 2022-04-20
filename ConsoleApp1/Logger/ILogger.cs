using System;

namespace ConsoleApp1
{
    public interface ILogger : IDisposable
    {
        void Log(params string[] messages);
    }
}