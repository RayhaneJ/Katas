using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetStarter.Logic
{
    public class Account
    {
        private int amount;
        private readonly List<Transaction> transactions = new List<Transaction>();

        public void Deposit(int amount)
        {
            var finalAmount = this.amount += amount;
            transactions.Add(new Transaction { Amount = amount, Date = DateTime.Now, Balance = finalAmount, TransactionType = TransactionType.Deposit });
            this.amount = finalAmount;
        }

        public void Withdraw(int amount)
        {
            var finalAmount = this.amount - amount;
            if (finalAmount < 0)
                finalAmount = 0;
            else 
                this.amount = finalAmount;
            transactions.Add(new Transaction { Amount = amount, Date = DateTime.Now, Balance = finalAmount, TransactionType = TransactionType.Withdraw });
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(string.Format("|{0,-5}|{1,-5}|{2,-5}", "Date", "Amount", "Balance"));
            transactions.ForEach(transaction => stringBuilder.AppendLine(transaction.ToString()));
            return stringBuilder.ToString();
        }
    }
}
