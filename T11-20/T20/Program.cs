namespace Mammals
{
    abstract class Mammal
    {
        private int _age;
        public int Age
        {
            get => _age;
            set => _age = value;
        }
        abstract public string Move();
    }
    class Human : Mammal
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public void Grow()
        {
            Age = Age + 1;
        }
        public override string Move()
        {
            return "Moving";
        }
    }
    class Baby : Human
    {
        public string feature = "diaper";
        public override string Move()
        {
            return "Crawling";
        }
    }
    class Adult : Human
    {
        public string Auto;
        public override string Move()
        {
            return "Walking";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] check = { "exit", "q", "e", "quit" };
            Baby babby = new Baby();
            babby.Name = "Bab";
            babby.Height = 0.5;
            babby.Weight = 20;
            babby.Age = 1;
            Adult tyyne = new Adult();
            tyyne.Name = "Tyyne";
            tyyne.Height = 1.7;
            tyyne.Weight = 75;
            tyyne.Age = 27;
            Adult jarkko = new Adult();
            jarkko.Name = "Jarkko";
            jarkko.Height = 1.74;
            jarkko.Weight = 89;
            jarkko.Age = 33;
            while (true)
            {
                Console.WriteLine("___  ___                                _     \r\n|  \\/  |                               | |    \r\n| .  . | __ _ _ __ ___  _ __ ___   __ _| |___ \r\n| |\\/| |/ _` | '_ ` _ \\| '_ ` _ \\ / _` | / __|\r\n| |  | | (_| | | | | | | | | | | | (_| | \\__ \\\r\n\\_|  |_/\\__,_|_| |_| |_|_| |_| |_|\\__,_|_|___/\r\n                                              ");
                Console.WriteLine("Current people:");
                Console.WriteLine($"Name: {babby.Name} Age: {babby.Age} Height: {babby.Height} Weight: {babby.Weight}. {babby.Name} moves by {babby.Move()}");
                Console.WriteLine($"Name: {tyyne.Name} Age: {tyyne.Age} Height: {tyyne.Height} Weight: {tyyne.Weight}. {tyyne.Name} moves by {tyyne.Move()}");
                Console.WriteLine($"Name: {jarkko.Name} Age: {jarkko.Age} Height: {jarkko.Height} Weight: {jarkko.Weight}. {jarkko.Name} moves by {jarkko.Move()}");
                Console.WriteLine("You can age a person up by one year by selecting 1-3 who to age up. Writing 'q' 'exit' or 'quit' exits the program.");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    babby.Grow();
                    Console.Clear();
                }
                else if (input == "2")
                {
                    tyyne.Grow();
                    Console.Clear();
                }
                else if (input == "3")
                {
                    jarkko.Grow();
                    Console.Clear();
                }
                else if (check.Contains(input.ToLower())) 
                {
                    { break; }
                }
                else
                {
                    Console.WriteLine("Invalid option, try again.");
                }
            }
        }
    }
}