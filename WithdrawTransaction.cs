using Accounts;
namespace BankSystem
{
    class WithdrawTransaction : Transaction
    {

        public Account account;

        public WithdrawTransaction(Account account, decimal Amount)
            : base(Amount)

        {
            this.account = account;
            this.Amount = Amount;
        }

        public override void Print()
        {
            Console.WriteLine("Status of transaction: " + executed);
            Console.WriteLine("Amount withdrawn: $" + Amount);
        }

        public override void Execute()
        {

            if (executed)
            {
                throw new InvalidOperationException("Transaction already attempted");
            }
            else if (!executed)
            {
                if (account.Withdraw(Amount))
                {
                    executed = true;
                    success = true;
                }
                else if (!account.Withdraw(Amount))
                {
                    success = false;
                }
            }
            if (!success)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
        }

        public override void RollBack()
        {
            if (!success)
            {
                throw new InvalidOperationException("Origional withdraw operation has not been finalized");
            }
            if (reversed)
            {
                throw new InvalidOperationException("Withdraw has already been reversed");
            }
            else if (!reversed)
            {
                if (account.Deposit(Amount))
                {
                    reversed = true;
                }
            }
        }

      

    }
}
