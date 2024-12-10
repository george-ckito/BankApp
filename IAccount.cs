using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal interface IAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool Blocked { get; set; }
        public bool Transfer(Card fromCard, Account toAccount, Card toCard, decimal amount);
    }
}
