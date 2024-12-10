using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal struct Transaction
    {
        public string fromAccount { get; set; }
        public Card fromCard { get; set; }
        public Card toCard { get; set; }
        public string toAccount { get; set; }
        public decimal amount { get; set; }
    }
}
