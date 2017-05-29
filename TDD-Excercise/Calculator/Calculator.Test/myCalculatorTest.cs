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
    }
}
