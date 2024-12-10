using BankApp;
Utility.PrintTitle();
List<int> cards = Utility.GenerateCardsAmount();
List<Account> accounts = Utility.GenerateAccounts(cards, 5);
while(true)
{
    Utility.GetUserOption(cards, accounts);
}