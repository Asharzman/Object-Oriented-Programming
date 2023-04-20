namespace Cashier
{
    public interface ITransaction
    {
        // interface members
        string ShowTransaction();
        float Money { get; set; }
    }

    public class PaidWithCash : ITransaction
    {
        private static float totalCash = 0;
        private float cash;

        public PaidWithCash(float cash)
        {
            this.cash = cash;
            totalCash += cash;
        }

        public string ShowTransaction()
        {
            return $"Paid with cash: bill number {DateTime.Now.Ticks} date {DateTime.Now.ToShortDateString()} amount {cash}e";
        }

        public float Money
        {
            get { return cash; }
            set { cash = value; }
        }

        public static float ShowCash()
        {
            return totalCash;
        }
    }

    public class PaidWithCard : ITransaction
    {
        private static float totalCard = 0;
        private float card;

        public PaidWithCard(float card)
        {
            this.card = card;
            totalCard += card;
        }

        public string ShowTransaction()
        {
            return $"Transaction to bank: charge from card 0001-0002 date {DateTime.Now.ToShortDateString()} amount {card}e";
        }

        public float Money
        {
            get { return card; }
            set { card = value; }
        }

        public static float ShowTotal()
        {
            return totalCard;
        }
    }

    public class Program
    {
        public static void Main()
        {
            // make payments
            ITransaction cash1 = new PaidWithCash(100);
            ITransaction cash2 = new PaidWithCash(50);
            ITransaction card1 = new PaidWithCard(78.95f);
            ITransaction card2 = new PaidWithCard(45.65f);

            // show transactions
            Console.WriteLine(" _____           _     _           \r\n/  __ \\         | |   (_)          \r\n| /  \\/ __ _ ___| |__  _  ___ _ __ \r\n| |    / _` / __| '_ \\| |/ _ \\ '__|\r\n| \\__/\\ (_| \\__ \\ | | | |  __/ |   \r\n \\____/\\__,_|___/_| |_|_|\\___|_|   \r\n                                   \r\n                                   ");
            Console.WriteLine(card1.ShowTransaction());
            Console.WriteLine(card2.ShowTransaction());
            Console.WriteLine($"Total money at bank account: {PaidWithCard.ShowTotal()}e");
            Console.WriteLine(cash1.ShowTransaction());
            Console.WriteLine(cash2.ShowTransaction());
            Console.WriteLine($"Total money in cash: {PaidWithCash.ShowCash()}e");
            Console.WriteLine($"Total sales today {DateTime.Now.ToString("dddd MMMM d, yyyy")} is {PaidWithCard.ShowTotal() + PaidWithCash.ShowCash()}e");

            Console.WriteLine("Program completed successfully. Press any key to quit.");
            Console.ReadKey();
        }
    }
}