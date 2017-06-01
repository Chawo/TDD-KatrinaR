using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TheBank;
using NSubstitute;

namespace BankTests
{
    [TestFixture]
    public class BankTest
    {
        private Bank sut;
        private IAuditLogger dbStub; 

        [SetUp]
        public void Setup()
        {
            dbStub = Substitute.For<IAuditLogger>();
            sut = new Bank(dbStub);
        }

        [Test]
        public void CanCreateBankAccount()
        {
            Account newAccount = new Account()
            {
                Number = "1001",
                Name = "Kalle Anka",
                Balance = 0M
            };

            sut.CreateAccount(newAccount);
            var expected = sut.GetAccount(newAccount.Number);

            Assert.AreEqual("1001", expected.Number);
            Assert.AreEqual("Kalle Anka", expected.Name);
            Assert.AreEqual(0, expected.Balance);
        }

        [Test]
        public void CanNotCreateDuplicateAccounts()
        {
            Account newAccount1 = new Account()
            {
                Number = "1001",
                Name = "Kalle Anka",
                Balance = 0M
            };

            Account newAccount2 = new Account()
            {
                Number = "1001",
                Name = "Kajsa Anka",
                Balance = 0M
            };

            sut.CreateAccount(newAccount1);

            Assert.Throws<DuplicateAccount>(() => sut.CreateAccount(newAccount2));

        }

        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {
            Account newAccount = new Account()
            {
                Number = "1001",
                Name = "Kalle Anka",
                Balance = 0M
            };

            sut.CreateAccount(newAccount);

            // Mockar kan faila eller passera ett test.
            dbStub.Received().AddMessage(Arg.Is<string>(s => s.Contains(newAccount.Number) && s.Contains(newAccount.Name)));

        }

        [Test]
        public void WhenCreatingAnValidAccount_OneMessageAreWrittenToTheAuditLog()
        {
            Account newAccount = new Account()
            {
                Number = "1001",
                Name = "Kalle Anka",
                Balance = 0M
            };

            sut.CreateAccount(newAccount);

            dbStub.Received(1).AddMessage(Arg.Is<string>(s => s.Contains(newAccount.Number) && s.Contains(newAccount.Name)));
        }

        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            Account newAccount = new Account()
            {
                Number = "1001",
                Name = "Kalle Anka",
                Balance = 0M
            };

            Account newAccount2 = new Account()
            {
                Number = "1003",
                Name = "Katrina Rosales",
                Balance = 0M
            };

            sut.CreateAccount(newAccount);
            sut.CreateAccount(newAccount2);

            dbStub.Received(2).AddMessage(Arg.Any<string>());
        }

        [Test]
        public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
        {
            Account newAccount = new Account()
            {
                Number = "K",
                Name = "Mia Pärsson",
                Balance = 0M
            };

            //sut.CreateAccount(newAccount);
            // Det här gick inte i börjar eftersom det fanns exception i Bank klassen, innan hade vi inte den här koden under och då blev det röd eftersom exception gjorde att testet kraschade och då går det inte igenom i koder under den här koden.
            Assert.Throws<InvalidAccount>(() => sut.CreateAccount(newAccount));

            dbStub.Received(2).AddMessage(Arg.Is<string>(s=>s.Contains("Warn12:") || s.Contains("Error45:")));

            
        }

        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        {

            //We need to verify that when we call GetAuditLog on the bank object, that it do actually call the AuditLogger.GetLog() method. 
            //Setup the test so that the GetLog() method on the audit logger returns a list of three items. 
            //Use the mocking feature in NSubstitute to do this. Make sure in the test these three items are returned from the GetAuditLog Method. 

            // Jag ska bestämma i mitt test vad mitt metod _auditlogger.GetLog() ska få ut.


            //Eget mockop
            dbStub.GetLog().Returns(new List<string>() { "string1", "string2" });

            var result = sut.GetAuditLog();

            Assert.AreEqual("string1", result[0]);
            Assert.AreEqual("string2", result[1]);
        }
    }
}
