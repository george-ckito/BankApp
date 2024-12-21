using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    internal class InvalidTransferAmountException : Exception
    {
        public InvalidTransferAmountException() : base("The amount you're trying to transfer is invalid!") { }
    }
}
