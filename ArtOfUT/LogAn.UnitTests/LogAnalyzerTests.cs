using NUnit.Framework;
using System;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer m_analyzer = null;

        /// <summary>
        /// 尽量少用Setup，也会降低可读性
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            m_analyzer = new LogAnalyzer();
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnFalse()
        {
            var logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnTrue()
        {
            var logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName("filewithbadextension.SLF");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnTrue()
        {
            var logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName("filewithbadextension.slf");

            Assert.True(result);
        }

        /// <summary>
        /// 推荐写法
        /// </summary>
        /// <param name="flieName"></param>
        [TestCase("filewithbadextension.SLF")]
        [TestCase("filewithbadextension.slf")]
        public void IsValidLogFileName_ValidExtension_ReturnTrue(string flieName)
        {
            var logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName(flieName);

            Assert.True(result);
        }

        /// <summary>
        /// 不推荐，阅读性降低
        /// </summary>
        /// <param name="flieName"></param>
        /// <param name="expected"></param>
        [TestCase("filewithbadextension.SLF", true)]
        [TestCase("filewithbadextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidLogFileName_VariousExtensions_ChecksThem(string flieName, bool expected)
        {
            var logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName(flieName);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase2_ReturnTrue()
        {
            bool result = m_analyzer.IsValidLogFileName("filewithbadextension.slf");

            Assert.True(result);
        }

        /// <summary>
        /// 老版本写法 不推荐  可能会欺骗你
        /// </summary>
        //[Test]
        //[ExpectedException(typeof(ArgumentException),ExpectedMessage = "filename has to be provided")]
        //public void IsValidFileName_EmptyFileName_ThrowsException()
        //{
        //    m_analyzer.IsValidLogFileName(string.Empty);
        //}

        //捕获异常的 推荐写法
        [Test]
        public void IsValidLogFileName_FileNameIsEmpty_ThrowException()
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();

            var ex = Assert.Catch<Exception>(() => logAnalyzer.IsValidLogFileName(""));

            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        /// <summary>
        /// Fulent语法，一般写法越简单约好
        /// </summary>
        [Test]
        public void IsValidLogFileName_FileNameIsEmpty_ReturnTrueFluent()
        {
            LogAnalyzer la = MakeAnalyzer();

            bool result = la.IsValidLogFileName("filewithbadextension.slf");

            Assert.That(result==true);
        }

        /// <summary>
        /// 给测试分类，使用Category特性
        /// </summary>
        [Test]
        [Category("Fast Tests")]
        [TestCase("filewithbadextension.slf")]
        [TestCase("filewithbadextension.Slf")]
        public void IsValidLogFileName_CategoryTest_ReturnTrue(string fileName)
        {
            LogAnalyzer la = MakeAnalyzer();

            bool result = la.IsValidLogFileName(fileName);

            Assert.IsTrue(result);
        }

        [Test]
        [Ignore("This is a ignore test!")]
        public void IsValidFileName_IgnoreTest_ShouldIgnore()
        {
            var la = MakeAnalyzer();

            bool result = la.IsValidLogFileName("filewithbadextension.slf");

            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid()
        {
            var la = MakeAnalyzer();

            var result = la.IsValidLogFileName("badname.foo");

            Assert.IsFalse(la.WasLastFileNameValid);
        }

        [TestCase("badname.foo",false)]
        [TestCase("goodname.slf",true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName,bool expected)
        {
            var la = MakeAnalyzer();

            var result = la.IsValidLogFileName(fileName);

            Assert.AreEqual(expected,la.WasLastFileNameValid);
        }

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [TearDown]
        public void Teardown()
        {
            //一般不用，不然可能把单元测试写成了集成测试。
            //只有在重置静态变量或者单例时使用
        }
    }
}
