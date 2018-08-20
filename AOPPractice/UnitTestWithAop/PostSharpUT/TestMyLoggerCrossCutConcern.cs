using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PostSharp.Aspects;
using PostSharpUT;

namespace PostSharpUT
{
    [TestFixture]
    public class TestMyLoggerCrossCutConcern
    {
        [Test]
        public void TestMyBoundaryAspect()
        {
            //Arrange  准备阶段
            var args = new MethodExecutionArgs(null, Arguments.Empty);
            args.Method = new DynamicMethod("Farb", null, null);
            //Act   执行阶段
            var aspect = new MyBoundaryAspect();
            aspect.OnEntry(args);
            aspect.OnSuccess(args);
            //Assert    断言阶段
            Assert.IsTrue(Log.Messages.Contains("Before:" + args.Method.Name));
            Assert.IsTrue(Log.Messages.Contains("After:" + args.Method.Name));
        }
    }
}
