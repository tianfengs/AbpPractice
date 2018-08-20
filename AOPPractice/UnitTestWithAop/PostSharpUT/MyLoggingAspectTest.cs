using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PostSharp.Aspects;
using PostSharpUT.Complex;
using StructureMap;

namespace PostSharpUT
{
    [TestFixture]
    public class MyLoggingAspectTest
    {
        [Test]
        public void TestIntercept()
        {
            var mockedLoggingService = new Mock<ILoggingService>();
            var args=new MethodExecutionArgs(null,Arguments.Empty);
            ObjectFactory.Initialize(x =>
            x.For<ILoggingService>().Use(mockedLoggingService.Object));
            var loggingAspect=new LoggingAspect();
            loggingAspect.RuntimeInitialize(null);
            loggingAspect.OnEntry(args);
            loggingAspect.OnSuccess(args);

            mockedLoggingService.Verify(x=>x.Write("Log start"));
            mockedLoggingService.Verify(x=>x.Write("Log end"));
        }
    }
}
