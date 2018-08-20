using Castle.DynamicProxy;
using static System.Console;
namespace DynamicProxyComposeAspects
{
    public class Aspect1 : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            WriteLine($"This is {nameof(Aspect1)}");
        }
    }

    public class Aspect2 : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            WriteLine($"This is {nameof(Aspect2)}");
        }
    }
}
