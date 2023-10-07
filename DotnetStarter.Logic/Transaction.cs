using System;
using System.Text;

namespace DotnetStarter.Logic
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
        public TransactionType TransactionType { get; set; }

        public override string ToString()
        {
            char type = (char)TransactionType;
            return string.Format("|{0,-5}|{1,-5}|{2,-5}", Date.ToString(), $"{type}{Amount}", Balance);
        }
    }

    public enum TransactionType
    {
        Withdraw = '-', Deposit = '+'
    }
}