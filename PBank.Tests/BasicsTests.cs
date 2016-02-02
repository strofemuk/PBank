using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PBank.Business;

namespace PBank.Tests
{
    [TestClass]
    public class BasicsTests
    {
        private Bank _bank;

        [TestInitialize]
        public void Init()
        {
            _bank = new Bank();
        }

        [TestClass]
        public class BankTests : BasicsTests
        {
            [TestMethod]
            public void Can_Create_User()
            {
                Assert.Fail();
            }

            [TestMethod]
            public void Cannot_Create_User_Who_Already_Exists()
            {
                Assert.Fail();
            }

            [TestMethod]
            public void Can_Create_Account()
            {
                Assert.Fail();
            }

            [TestMethod]
            public void Can_Delete_Account()
            {
                Assert.Fail();
            }

            [TestMethod]
            public void Cannot_Delete_Account_With_Balance()
            {
                Assert.Fail();
            }
        }

        [TestClass]
        public class TellerTests : BasicsTests
        {
            [TestMethod]
            public void Can_Deposit()
            {
                Assert.IsTrue(_bank.NextTeller.Deposit(300.0F, _bank.Accounts[1]).Success);
            }

            [TestMethod]
            public void Can_Withdrawl()
            {
                Assert.IsTrue(_bank.NextTeller.Withdraw(200.0F, _bank.Accounts[1]).Success);
            }

            [TestMethod]
            public void Cannot_Withdraw_More_Than_Balance()
            {
                Assert.IsFalse(_bank.NextTeller.Withdraw(3000.0F, _bank.Accounts[1]).Success);
            }

            [TestMethod]
            public void Can_Close_Account()
            {
                float amount = _bank.Accounts[3].Balance;
                _bank.NextTeller.Withdraw(amount, _bank.Accounts[3]);
                Assert.IsTrue(_bank.NextTeller.Close(_bank.Accounts[3]).Success);
            }

            [TestMethod]
            public void Cannot_Close_Account_With_Balance()
            {
                Assert.IsFalse(_bank.NextTeller.Close(_bank.Accounts[1]).Success);
            }

            [TestMethod]
            public void Can_Withdraw_Exact_Balance()
            {
                float amount = _bank.Accounts[3].Balance;
                Assert.IsTrue(_bank.NextTeller.Withdraw(amount, _bank.Accounts[3]).Success);
            }
        }
    }
}
