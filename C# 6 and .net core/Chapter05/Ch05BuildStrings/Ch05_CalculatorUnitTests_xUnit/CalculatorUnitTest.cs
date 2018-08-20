using Ch05Caculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ch05_CalculatorUnitTests_xUnit
{
    public class CalculatorUnitTest
    {
        [Fact]
        public void TestAdding2And2()
        {
            // arrange
            double a = 2;
            double b = 2;
            double expected = 4;
            var calc = new Caculator();
            // act
            double actual = calc.Add(a, b);
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAdding2And3()
        {
            // arrange
            double a = 2;
            double b = 3;
            double expected = 5;
            var calc = new Caculator();
            // act
            double actual = calc.Add(a, b);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
