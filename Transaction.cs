namespace BankSystem
{
    class Transaction
    {
        public Transaction(decimal Amount)
        {
            this.Amount = Amount;
        }


        public decimal Amount;
        public bool success;
        public bool executed;
        public bool reversed;
        DateTime dateStamp;



        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        public bool Executed
        {
            get { return executed; }
            set { executed = value; }

        }

        public bool Reversed
        {
            get { return reversed; }
            set { reversed = value; }
        }

        public DateTime DateStamp
        {
            get { return dateStamp; }
            set { dateStamp = DateTime.Now; }
        }

        public virtual void Print()
        {

        }

        public virtual void Execute()
        {
            
        }

        public virtual void RollBack()
        {

        }

    }
}
