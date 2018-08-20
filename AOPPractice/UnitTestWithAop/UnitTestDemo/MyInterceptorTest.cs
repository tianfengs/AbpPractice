using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Moq;
using NUnit.Framework;

namespace PostSharpUT
{
    [TestFixture]
    public class MyInterceptorTest
    {
        [Test]
        public void TestIntercept()
        {
            var myInterceptor=new MyInterceptor();
            //IInvocation invocation;//这里先不赋值，下面接着说
            var mockedInvocation=new Mock<IInvocation>();
            mockedInvocation.Setup(m => m.Method.Name).Returns("MyMethod");//Arrange:将被拦截的方法的Name属性设置为MyMethod
            var invocation = mockedInvocation.Object;//使用Object属性获得要传入的真实对象
            myInterceptor.Intercept(invocation);
            Assert.IsTrue(Log.Messages.Contains(invocation.Method.Name+"执行前"));
            Assert.IsTrue(Log.Messages.Contains(invocation.Method.Name+"执行后"));
        }
    }
}
