using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Exceptions;

namespace BankApp
{
    internal class Account : IAccount
    {
        private static Random rand = new Random();
        public List<Transaction> History = new List<Transaction>();
        public static List<Transaction> UniversalHistory = new List<Transaction>();
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool Blocked { get; set; }
        private readonly Dictionary<string, decimal> Rates = new Dictionary<string, decimal>();
        public List<Card> Cards = new List<Card>();

        
        private string GenerateRandomAccountNumber()
        {
            StringBuilder strb = new StringBuilder("GE");
            for (int i = 0; i < 10; i++)
            {
                strb.Append(rand.Next(10));
            }
            return strb.ToString();
        }
        private bool GenerateRandomBlocked()
        {
            return rand.Next(2) == 0;
        }
        public Account()
        {
            AccountNumber = GenerateRandomAccountNumber();
            Blocked = GenerateRandomBlocked();
            decimal bal = 0;
            foreach(Card card in Cards)
            {
                bal += card.Balance;
            }
            Rates.Add("USD", 3.5m);
            Rates.Add("EUR", 4.0m);
            Rates.Add("GBP", 4.5m);
            Rates.Add("RUB", 0.05m);
            Rates.Add("TRY", 0.5m);
        }
        public void AddCard(Card card)
        {
            Cards.Add(card);
            Balance += card.Balance;
        }
        public void AddCard()
        {
            if (rand.Next(2) == 1)
            {
                CreditCard cc = new CreditCard(this);
                AddCard(cc);
            }
            else
            {
                DebitCard dc = new DebitCard(this);
                AddCard(dc);
            }
        }
        public void Block()
        {
            Blocked = true;
        }
        public void Unblock()
        {
            Blocked = false;
        }
        public Card getCard(int index)
        {
            if (index < 0 || index >= Cards.Count)
            {
                return null;
            }
            return Cards[index];
        }
        public void PrintCards()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine($"\t Card {Cards.IndexOf(card) + 1}");
                card.Print();
                Console.WriteLine();
            }
        }
        public void Transfer(Card fromCard, Account toAccount, Card toCard, decimal amount)
        {
            if (Blocked || toAccount.Blocked)
            {
                throw new AccountBlockedException();
            }
            if (fromCard.Balance < amount || amount <= 0)
            {
                throw new InvalidTransferAmountException();
            }
            if (fromCard == toCard)
            {
                throw new Exception("You can't transfer money to the same card!");
            }
            Balance -= amount;
            fromCard.Balance -= amount;
            toAccount.Balance += amount;
            toCard.Balance += amount;
            Transaction transaction = new Transaction();
            transaction.fromAccount = AccountNumber;
            transaction.fromCard = fromCard;
            transaction.toAccount = toAccount.AccountNumber;
            transaction.toCard = toCard;
            transaction.amount = amount;
            History.Add(transaction);
            UniversalHistory.Add(transaction);
        }
        public void PrintHistory()
        {
            Console.WriteLine($"History of account {AccountNumber}:");
            foreach (Transaction transaction in History)
            {
                Console.WriteLine($"\t{transaction.fromAccount} -> {transaction.toAccount} ---- {transaction.amount}");
            }
        }
        public static void PrintUniversalHistory()
        {
            Console.WriteLine("Universal history:");
            foreach (Transaction transaction in UniversalHistory)
            {
                Console.WriteLine($"\t{transaction.fromAccount} -> {transaction.toAccount} ---- {transaction.amount}");
            }
        }
        public decimal GetRate(string valute)
        {
            if (Rates.ContainsKey(valute))
            {
                return Rates[valute];
            }
            return 0;
        }
        public decimal ConvertTo(decimal amount, string valute)
        {
            decimal rate = GetRate(valute);
            if (rate == 0)
            {
                return 0;
            }
            return amount * rate;
        }
    }
}
