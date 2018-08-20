using Castle.DynamicProxy;
using Moq;
using NUnit.Framework;

namespace CastleDynamicProxyUT.UT
{
    [TestFixture]
    public class LoggingAspectTest
    {
        [Test]
         public void TestIntercept()
        {
            var mockedLoggingService=new Mock<ILoggingService>();//为ILoggingService创建一个伪造对象
            var loggingAspect=new LoggingAspect(mockedLoggingService.Object);//使用伪造对象的Object属性实例化LoggingAspect
            var mockedInvocation=new Mock<IInvocation>();//为IInvoation对象创建一个伪造对象
            loggingAspect.Intercept(mockedInvocation.Object);
            mockedLoggingService.Verify(x=>x.Write("Log start"));//使用伪造对象的Verify验证Write方法是否像期待的那样执行
            mockedLoggingService.Verify(x=>x.Write("Log end"));
        }
    }
}