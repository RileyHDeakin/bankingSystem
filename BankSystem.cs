
using Accounts;
using BankSystem;

enum MenuOption
{
    Withdraw,
    Deposit,
    Print,
    Transfer,
    AddAccount,
    TransactionHistory,
    Quit
}


class banksystem
{
    static int readUserOption()
    {

        int userOption;
        do
        {

            Console.WriteLine("1 - Withdraw");
            Console.WriteLine("2 - Deposit");
            Console.WriteLine("3 - Print");
            Console.WriteLine("4 - Transfer");
            Console.WriteLine("5 - Add Account");
            Console.WriteLine("6 - Transaction History");
            Console.WriteLine("7 - Quit");
            userOption = Convert.ToInt32(Console.ReadLine());
        }


        while (false);
        return userOption;
    }

    static Account FindAccount(List<Account> Accounts)
    {
        Console.WriteLine("Enter name of Account: ");
        string FindAccount = Console.ReadLine();
        return Bank.GetAccount(FindAccount);
    }

    static void doDeposit(List<Account> Accounts)
    {
        Account account = FindAccount(Accounts);
        Console.WriteLine("Enter amount to deposit: ");
        decimal amount = Convert.ToInt32(Console.ReadLine());
        DepositTransaction Accountz = new DepositTransaction(account, amount);
        Bank.ExecuteTransaction(Accountz);
        Console.WriteLine("Total Balance is now: " + account.balance);
    }

    static void Transfer(List<Account> Accounts)
    {
        Console.WriteLine("Transfer from: ");
        Account FromAccount = FindAccount(Accounts);
        Console.WriteLine("Transfer To: ");
        Account ToAccount = FindAccount(Accounts);
        Console.WriteLine("Enter amount to transfer: ");
        decimal TransferAmount = Convert.ToInt32(Console.ReadLine());
        TransferTransaction Transfer = new TransferTransaction(FromAccount, ToAccount, TransferAmount);
        Bank.ExecuteTransaction(Transfer);
    }

    static void doWithdraw(List<Account> Accounts)
    {
        Account account = FindAccount(Accounts);
        Console.WriteLine("Enter amount to withdraw: ");
        decimal withdrawAmount = Convert.ToInt32(Console.ReadLine());
        WithdrawTransaction Account = new WithdrawTransaction(account, withdrawAmount);
        Bank.ExecuteTransaction(Account);
        Console.WriteLine("Total Balance is now: " + account.balance);

    }



    static void doPrint(List<Account> Accounts)
    {
        Account account = FindAccount(Accounts);
        account.Print();
    }



    static void Main()
    {

        Account Riley = new Account("Riley", 20000);
        Account Jack = new Account("Jack", 15000);
        Account Daniel = new Account("Daniel", 10000);
        Bank.Accounts.Add(Jack);
        Bank.Accounts.Add(Riley);
        Bank.Accounts.Add(Daniel);
        int userInput = readUserOption();
        switch (userInput)
        {
            case 1:
                doWithdraw(Bank.Accounts);
                Main();
                break;
            case 2:
                doDeposit(Bank.Accounts);
                Main();
                break;
            case 3:
                doPrint(Bank.Accounts);
                Main();
                break;
            case 4:
                Transfer(Bank.Accounts);
                Main();
                break;
            case 5:
                Console.WriteLine("Enter name of new account: ");
                String NewName = Console.ReadLine();
                Console.WriteLine("Enter starting balance: ");
                decimal StartBalance = Convert.ToInt32(Console.ReadLine());
                Account Account = new Account(NewName, StartBalance);
                Bank.AddAccount(Account);
                Main();
                break;
            case 6:
                Bank.PrintTransactionHistory(Bank.Transactions);
                Main();
                break;
            case 7:
                break;


        }
    }

}
