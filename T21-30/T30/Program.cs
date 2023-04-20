namespace Interface
{
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal GetBalance();
    }

    public class SavingsAccount : IBankAccount
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    public class CheckingAccount : IBankAccount
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (balance - amount >= -500)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
}