using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ValidationEngine;

namespace ValidationEngineTests
{
    [TestFixture]
    public class EmailValidation
    {
        [Test]
        public void SendingInTrueValidation()
        {
            string EmailAdress = "mejl@live.com";

            var sut = new emailAdress(EmailAdress);

            var istrue = sut.ValidAdress();

            Assert.IsTrue(istrue);
        }

        [Test]
        public void SendingInFalseValidation()
        {
            string EmailAdress = "Test.com";

            var sut = new emailAdress(EmailAdress);

            var isfalse = sut.ValidAdress();

            Assert.IsFalse(isfalse);
        }

        [Test]
        public void SendingInNullValidation()
        {
            string EmailAdress = "";

            var sut = new emailAdress(EmailAdress);

            var isFalseIfNull = sut.ValidAdress();

            Assert.IsFalse(isFalseIfNull);
        }
    }
}
