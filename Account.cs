

namespace Accounts
{
    public class Account
    {
        public string name;
        public decimal balance;

        public Account(String name, decimal balance)
        {
            this.name = name;
            this.balance = balance;
        }

        public Boolean Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                return false;
            }
            else
            {
                balance -= amount;
                return true;
            }

        }

        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Balance: " + balance);
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
