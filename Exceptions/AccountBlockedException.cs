using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Exceptions
{
    internal class AccountBlockedException : Exception
    {
        public AccountBlockedException() : base("The account you're trying to use is blocked!") { }
    }
}
