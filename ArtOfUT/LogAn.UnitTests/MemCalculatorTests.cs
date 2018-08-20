using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class MemCalculatorTests
    {

        /*测试方法名 命名规则 UnitOfWork]_[Scenario]_[ExpectedBehavior]*/
        /// <summary>
        /// 从最简单的测试开始
        /// </summary>
        [Test]
        public void Sum_ByDefault_ReturnZero()
        {
            var mc = MakeCalc();

            var lastSum = mc.Sum();

            Assert.AreEqual(0, lastSum);
        }

        [Test]
        public void Sum_WhenCalled_ChangesSum()
        {
            var mc = MakeCalc();
            mc.Add(1);
            int sum = mc.Sum();
            Assert.AreEqual(1,sum);
        }

        private MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }
    }
}
