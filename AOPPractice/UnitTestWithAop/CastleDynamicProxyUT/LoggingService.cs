using System;

namespace CastleDynamicProxyUT
{
    public class LoggingService : ILoggingService
    {
        public void Write(string message)
        {
            Console.WriteLine("Logging:"+message);
        }
    }
}