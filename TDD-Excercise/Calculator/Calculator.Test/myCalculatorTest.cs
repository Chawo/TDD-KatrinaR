using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using NUnit.Framework;

namespace Calculator.Test
{
    public class myCalculatorTest
    {
        myCalculator sut = new myCalculator();

        [Test]
        [TestCase ("")]
        public void ReturnZero(string addNumbers)
        {
            var number = sut.Add(addNumbers);
            Assert.AreEqual(0, number);
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        public void ReturnGivingNumber(int expected, string addNumbers)
        {
            var number = sut.Add(addNumbers);
            Assert.AreEqual(expected, number);
        }

        [Test]
        [TestCase(3, "1,2")]
        [TestCase(6, "1,2,3")]
        public void ReturnSumOfNumbers(int expected, string addNumbers)
        {
            var number = sut.Add(addNumbers);
            Assert.AreEqual(expected, number);
        }

        [Test]
        [TestCase(6, "1\n2,3")]
        [TestCase(1, "1,\n")]
        [TestCase(8, "1,\n,\r,3\n,4")]
        public void TestDiffrentWithoutCommas(int expected, string addNumbers)
        {
            var number = sut.Add(addNumbers);
            Assert.AreEqual(expected, number);
        }

        [TestCase(3, "//;\n1;2")]
        public void MakeSemiColonDefaultDelimiter(int expected, string addNumbers)
        {
            var number = sut.Add(addNumbers);
            Assert.AreEqual(expected, number);
        }
    }
}
