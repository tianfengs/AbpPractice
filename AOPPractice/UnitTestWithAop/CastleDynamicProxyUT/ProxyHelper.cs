using Castle.DynamicProxy;
using StructureMap;

namespace CastleDynamicProxyUT
{
    public class ProxyHelper
    {
        private readonly ProxyGenerator _proxyGenerator;
        public ProxyHelper()
        {
            _proxyGenerator = new ProxyGenerator();//ProxyGenerator移到helper类中
        }
        public object Proxify<I, A>(object obj) where A : IInterceptor//约束A只允许IInterceptor类型实参
        {
            var interceptor = (IInterceptor) ObjectFactory.GetInstance<A>();//StructureMap处理切面的依赖
            var result = _proxyGenerator.CreateInterfaceProxyWithTargetInterface(typeof (I),obj,interceptor);
            return result;
        }
    }
}