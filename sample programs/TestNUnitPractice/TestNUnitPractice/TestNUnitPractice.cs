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
            //default constructor
            public BankAccount()
            {

            }
            //parameterised constructor
            public BankAccount(double balance)
            {
                this.balance = balance;
            }

            public double Balance
            {
                get { return balance; }
            }
            //adding amount to balance
            public void add(double amount)
            {
                if(amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount));
                }
                balance += amount;
            }

            //reducing amount to balance
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
            //adding amount to another account and reducing from one account

            public void TransferFunds(BankAccount otherAccount, double amount)
            {
                if(otherAccount == null)
                {
                    throw new ArgumentNullException(nameof(otherAccount));
                }
                Withdraw(amount);
                otherAccount.add(amount);
            }
           //this attribute is used  to run this method and used for adding money
            [Test]
            public void Add_Money()
            {
                //creating instance with account balance
                BankAccount account = new BankAccount(10000);

                //adding amount
                account.add(5000);

                //checking our value is equal to account
                Assert.AreEqual(15000, account.Balance);
            }
            //this attribute is used  to run this method and used for reducing money
            [Test]
            public void Add_Negative_Money()
            {
                BankAccount account = new BankAccount(10000);
               Assert.Throws<ArgumentOutOfRangeException>(()=>account.add(-1000));
            }
            [Test]//withdraw money
            public void Withdraw_Money()
            {
                BankAccount account = new BankAccount(10000);
                account.Withdraw(5000);
                //checking both are equal
                Assert.AreEqual(5000, account.Balance);
            }
            [Test]
            //withdraw negative money checking whether exception came or not
            public void Withdraw_Negative_Money()
            {
                BankAccount account = new BankAccount(10000);
                Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-1000));
            }
            [Test]
            //withdraw more than balance money checking whether exception came or not
            public void Withdraw_Morethan_Balance_Money()
            {
                BankAccount account = new BankAccount(10000);
                Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(20000));
            }
            [Test]
            //transfer amount from one account to another
            public void Transfer()
            {
                BankAccount account = new BankAccount(10000);
                BankAccount otherAccount = new BankAccount();
                account.TransferFunds(otherAccount, 5000);
             
                //checking both are equal
                Assert.AreEqual(otherAccount.Balance, account.balance);
            }
            [Test]
            //Transfer Money To Null Account checking whether exception came or not
            public void TransferMoneyToNullAccount()
            {
                BankAccount account = new BankAccount(10000);
            
                Assert.Throws<ArgumentNullException>(() => account.TransferFunds(null,5000));
            }

            //This attribute taking multiple parameters then adding to the balance and checks the condition each time. 
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

                //checking both are equal
                Assert.IsTrue(account.balance >= 7000);
            }
        }

       
    }
}