using System.Security.Principal;
using NUnit;
using NUnit.Framework;
namespace TestNUnitPractice
{
    public class Tests
    {
        public class BankAccount
        {
            public double balance;
            public BankAccount()
            {

            }
            public BankAccount(double balance)
            {
                this.balance = balance;
            }
            public double Balance
            {
                get { return balance; }
            }
            public void add(double amount)
            {
                if(amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount));
                }
                balance += amount;
            }
            public void Withdraw(double amount)
            {
                if (amount > balance)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount));
                }
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount));
                }
                balance -= amount;
            }

            public void TransferFunds(BankAccount otherAccount, double amount)
            {
                if(otherAccount == null)
                {
                    throw new ArgumentNullException(nameof(otherAccount));
                }
                Withdraw(amount);
                otherAccount.add(amount);
            }
           
            [Test]
            public void Add_Money()
            {
                BankAccount account = new BankAccount(10000);
                account.add(5000);
                Assert.AreEqual(15000, account.Balance);
            }
            [Test]
            public void Add_Negative_Money()
            {
                BankAccount account = new BankAccount(10000);
               Assert.Throws<ArgumentOutOfRangeException>(()=>account.add(-1000));
            }
            public void Withdraw_Money()
            {
                BankAccount account = new BankAccount(10000);
                account.Withdraw(5000);
                Assert.AreEqual(5000, account.Balance);
            }
            [Test]
            public void Withdraw_Negative_Money()
            {
                BankAccount account = new BankAccount(10000);
                Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-1000));
            }
            [Test]
            public void Withdraw_Morethan_Balance_Money()
            {
                BankAccount account = new BankAccount(10000);
                Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(20000));
            }
            [Test]
            public void Transfer()
            {
                BankAccount account = new BankAccount(10000);
                BankAccount otherAccount = new BankAccount();
                account.TransferFunds(otherAccount, 5000);

                Assert.AreEqual(otherAccount.Balance, account.balance);
            }
            [Test]
            public void TransferMoneyToNullAccount()
            {
                BankAccount account = new BankAccount(10000);
            

                Assert.Throws<ArgumentNullException>(() => account.TransferFunds(null,5000));
            }
            [TestCase(3000,4000)]
            [TestCase(5000, 1000)]
            [TestCase(8000, 1000)]
            [TestCase(5000, 4000)]
            [TestCase(6000, 4000)]
            [TestCase(10000, 1000)]
            public void Money(double balance, double money)
            {
                BankAccount account = new BankAccount(balance);
                account.add(money);
                Assert.IsTrue(account.balance >= 7000);
            }
        }

       
    }
}