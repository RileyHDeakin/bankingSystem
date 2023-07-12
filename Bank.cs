using Accounts;

namespace BankSystem
{
    class Bank
    {
        public static List<Account> Accounts = new List<Account>();

        public static List<Transaction> Transactions = new List<Transaction>();
        public static void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public static Account GetAccount(String name)
        {
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Accounts[i].name == name)
                {
                    return Accounts[i];
                }

            }
            return null;
        }

        public static void ExecuteTransaction(Transaction Transaction)
        {
            Transactions.Add(Transaction);
            Transaction.Execute();
            Transaction.Print();

        }

        public static void RollBack(Transaction Transaction)
        {
            Transaction.RollBack();
        }

        public static void PrintTransactionHistory(List<Transaction> Transactions)
        {
            for (int i = 0; i < Transactions.Count; i++)
            {
                Console.WriteLine(Transactions[i].DateStamp);
                Console.WriteLine(Transactions[i].Success);

            }
        }

    }
}
