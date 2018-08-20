using Moq;
using NUnit.Framework;
using PostSharpUT.Complex;
using StructureMap;

namespace PostSharpUT.StringExample
{
    [TestFixture]
    public class MyStringExtensionTest
    {
        [Test]
        public void Reverse_Test()
        {
            var mockloggingService=new Mock<ILoggingService>();
            ObjectFactory.Initialize(x=>
                x.For<ILoggingService>().Use(mockloggingService.Object));
            //AspectSettings.On = false;
            var myStrObj=new MyStringExtension();
            var reversedStr = myStrObj.Reverse("hello");
            Assert.That(reversedStr,Is.EqualTo("olleh"));
        }

        [Test]
        public void ReverseWithNull_Test()
        {
            var myStrObj=new MyStringExtension();
            var reversedStr = myStrObj.Reverse(null);
            Assert.IsNull(reversedStr);
        }
    }
}
