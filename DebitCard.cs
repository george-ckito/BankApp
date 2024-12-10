using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class DebitCard : Card
    {
        public decimal fees;
        public bool T = false;
        public DebitCard(Account owner) : base(owner)
        {
            this.Owner = owner;
            this.fees = (decimal) new Random().NextDouble() * 5;
        }
        public override void Print()
        {
            Console.WriteLine("\t\tDebit Card:");
            base.Print();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t\tFees: {fees}");
            Console.ResetColor();
        }
    }
}
