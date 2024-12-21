using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal abstract class Card
    {
        protected static Random rand = new Random();
        public string Number { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
        public Account Owner { get; set; }
        private string Type { get; set; }
        public decimal Balance { get; set; }

        public bool T;


        private string GenerateRandomNumber()
        {
            StringBuilder strb = new StringBuilder("GE");
            for (int i = 0; i < 10; i++)
            {
                strb.Append(rand.Next(10));
            }
            return strb.ToString();
        }
        private string GenerateRandomCVV()
        {
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                strb.Append(rand.Next(10));
            }
            return strb.ToString();
        }
        private string GenerateRandomExpirationDate()
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(rand.Next(1, 13));
            strb.Append("/");
            strb.Append(rand.Next(20, 30));
            return strb.ToString();
        }
        private string GenerateRandomType()
        {
            string[] types = { "MasterCard", "Visa", "American Express" };
            return types[rand.Next(3)];
        }
        private decimal GenerateRandomBalance()
        {
            return rand.Next(10000);
        }
        public Card(Account owner)
        {
            Owner = owner;
            Number = GenerateRandomNumber();
            CVV = GenerateRandomCVV();
            ExpirationDate = GenerateRandomExpirationDate();
            Type = GenerateRandomType();
            Balance = GenerateRandomBalance();
        }
        public virtual void Print()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t\tCard number: {Number}");
            Console.WriteLine($"\t\tCVV: {CVV}");
            Console.WriteLine($"\t\tExpiration date: {ExpirationDate}");
            Console.WriteLine($"\t\tType: {Type}");
            Console.WriteLine($"\t\tBalance: {Balance}");
            Console.ResetColor();
        }

    }
}
