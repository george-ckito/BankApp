using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class CreditCard : Card
    {
        public int CreditScore;
        public bool T = true;
        public CreditCard(Account owner) : base(owner)
        {
            CreditScore = new Random().Next(1000);
        }
        public override void Print()
        {
            Console.WriteLine("\t\tCredit Card:");
            base.Print();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t\tCredit score: {CreditScore}");
            Console.ResetColor();
        }
    }
}
