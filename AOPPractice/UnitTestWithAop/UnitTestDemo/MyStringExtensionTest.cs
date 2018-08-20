using NUnit.Framework;

namespace PostSharpUT
{
    [TestFixture]
    public class MyStringExtensionTest
    {
        [Test]
        public void Reverse_Test()
        {
            var myStrObj=new MyStringExtension();
            var reversedStr = myStrObj.Reverse("hello");
            Assert.That(reversedStr,Is.EqualTo("olleh"));//断言语法根据使用的工具和爱好不同可以有很多写法
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
