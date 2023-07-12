using Accounts;

namespace BankSystem
{
    class TransferTransaction : Transaction
    {
        public Account FromAccount;
        public Account ToAccount;


        public TransferTransaction(Account FromAccount, Account ToAccount, decimal Amount)
            : base(Amount)
        {
            this.FromAccount = FromAccount;
            this.ToAccount = ToAccount;

        }

        public override void Print()
        {
            Console.WriteLine("Transferred $" + Amount + " from " + FromAccount.Name + " to " + ToAccount.Name);

        }

        public override void Execute()
        {
            if (executed)
            {
                throw new InvalidOperationException("Transfer transaction has already been executed");

            }
            else if (!executed)
            {
                if (FromAccount.Withdraw(Amount) && ToAccount.Deposit(Amount))
                {
                    executed = true;
                    success = true;
                    DateStamp = DateTime.Now;
                }
                else if (!FromAccount.Withdraw(Amount) && ToAccount.Deposit(Amount))
                {
                    success = false;
                }
                if (!success)
                {
                    throw new InvalidOperationException("Insufficient funds");
                }
            }
        }


        public override void RollBack()
        {
            if (!success)
            {
                throw new InvalidOperationException("Origional transfer transaction operation has not been finalized");
            }
            if (reversed)
            {
                throw new InvalidOperationException("Transfer transaction has already been reversed");
            }
            else if (!reversed)
            {
                if (ToAccount.Withdraw(Amount) && FromAccount.Deposit(Amount))
                {
                    reversed = true;
                }
            }
        }
    }
}

