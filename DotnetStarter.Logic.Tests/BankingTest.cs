using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class BankingTest
    {
        [Fact]
        public void DepositTest()
        {
            Account account = new Account();
            account.Deposit(600);
            Debug.WriteLine(account.ToString());
        }

        [Fact]
        public void WithdrawTest()
        {
            Account account = new Account();
            account.Deposit(600);
            account.Withdraw(700);
            Debug.WriteLine(account.ToString());
        }
    }
}
