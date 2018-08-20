using Castle.DynamicProxy;

namespace CastleDynamicProxyUT
{
    public class LoggingAspect:IInterceptor
    {
        private readonly ILoggingService _loggingService;

        public LoggingAspect(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }
        public void Intercept(IInvocation invocation)
        {
            _loggingService.Write("Log start");
            invocation.Proceed();
            _loggingService.Write("Log end");
        }
    }
}