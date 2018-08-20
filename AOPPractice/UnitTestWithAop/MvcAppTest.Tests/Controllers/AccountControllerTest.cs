using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcAppTest.Controllers;

namespace MvcAppTest.Tests.Controllers
{
    /// <summary>
    /// Summary description for AccountControllerTest
    /// </summary>
    [TestClass]
    public class AccountControllerTest
    {
        public AccountControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void LogOff()
        {
            var classUnderTest = typeof (AccountController);
            var allMethods = classUnderTest.GetMethods();
            var methodUnderTest = allMethods.Where(m => m.Name == "LogOff");
            foreach (MethodInfo methodInfo in methodUnderTest)
            {
                var attribute = Attribute.GetCustomAttribute(methodInfo, typeof(ValidateAntiForgeryTokenAttribute));
                Assert.IsNotNull(attribute);
            }
        }
    }
}
