using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    static internal class Utility
    {
        public static void PrintTitle()
        {
            Console.WriteLine("////////////////////////// Bank //////////////////////////");
        }
        public static List<Account> GenerateAccounts(List<int> cards, int amount = 3)
        {
            
            List<Account> accounts = new List<Account>();
            for (int i = 0; i < amount; i++)
            {
                Account acc = new Account();
                Random rand = new Random();
                int cardAmount = cards.ElementAt(i);
                List<Card> accCards = new List<Card>();
                for(int j = 0; j < cardAmount; j++)
                {
                    acc.AddCard();
                }
                accounts.Add(acc);
            }
            return accounts;
        }
        public static void PrintAccounts(List<Account> accounts)
        {
            Console.WriteLine($"Accounts:");
            foreach (Account account in accounts)
            {
                Console.WriteLine($"{accounts.IndexOf(account) + 1}. {account.AccountNumber}    Balance - {account.Balance}    {(account.Blocked ? "BLOCKED" : "")}");
                foreach(Card card in account.Cards)
                {
                    Console.WriteLine($"\t Card {account.Cards.IndexOf(card) + 1}");
                    card.Print();
                    Console.WriteLine();
                }
            }
        }
        public static List<int> GenerateCardsAmount(int count)
        {
            List<int> cards = new List<int>();
            for (int i = 0; i < count; i++)
            {
                cards.Add(new Random().Next(1, 4));
            }
            return cards;
        }
        public static void GetUserOption(List<int> cards, List<Account> accounts)
        {
            PrintAccounts(accounts);
            Console.WriteLine("1. Transfer");
            Console.WriteLine("2. Print account history");
            Console.WriteLine("3. Print universal history");
            Console.WriteLine("4. Add a new card to an account");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choose option: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    try
                    {
                        Console.Write("Choose account to transfer from: ");
                        int fromAccount = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("\nChoose the card to transfer from");
                        accounts[fromAccount].PrintCards();
                        int fromCard = int.Parse(Console.ReadLine()) - 1;
                        Console.Write("\nChoose account to transfer to: ");
                        int toAccount = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("\nChoose the card to transfer to");
                        accounts[toAccount].PrintCards();
                        int toCard = int.Parse(Console.ReadLine()) - 1;
                        Console.Write("\nEnter amount to transfer: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        accounts[fromAccount].Transfer(accounts[fromAccount].getCard(fromCard), accounts[toAccount], accounts[toAccount].getCard(toCard), amount)
                        Console.WriteLine("\nTransfer successful");
                    }
                    catch (FormatException fex)
                    {
                        throw;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\nTransfer failed: {e.Message}");
                    }
                    
                    break;
                case 2:
                    int account;
                    try
                    {
                        account = int.Parse(Console.ReadLine()) - 1;
                    } catch (FormatException fex) {
                        throw;
                    }
                    accounts[account].PrintHistory();
                    break;
                case 3:
                    Account.PrintUniversalHistory();
                    break;
                case 4:
                    Console.WriteLine("Choose account:");
                    int account1 = int.Parse(Console.ReadLine()) - 1;
                    accounts[account1].AddCard();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

    }
}
