namespace Collection_Program
{
    public class Template
    {
        private string _name;
        public string Name
        {
            get =>  _name;
            set => _name = value;
        }
        private string _condition;
        public string Condition
        {
            get => _condition;
            set => _condition = value;
        }
        public void Repair() 
        {
            Condition = "very good";
        }
    }
    public class TShirt : Template
    {
        public string Description = "seen some use";
    }
    public class Pants : Template
    {
        public string Description = "almost destroyed";
    }
    public class Hoodie : Template
    {
        public string Description = "almost brand new";
        private bool _hasHood = true;
        public bool hasHood
        {
            get => _hasHood;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] check = { "exit", "q", "e", "quit" };
            TShirt ts = new TShirt();
            Pants pants = new Pants();
            Hoodie hoodie = new Hoodie();
            ts.Name = "Band T-Shirt";
            ts.Condition = "good";
            pants.Name = "Old pants";
            pants.Condition = "very poor";
            hoodie.Name = "Blue hoodie";
            hoodie.Condition = "lightly used";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Wardrobe contains:");
                Console.WriteLine($"{ts.Name} in {ts.Condition} condition, {ts.Description}.");
                Console.WriteLine($"{pants.Name} in {pants.Condition} condition, {pants.Description}.");
                Console.WriteLine($"{hoodie.Name} in {hoodie.Condition} condition, {hoodie.Description}. It has hood {hoodie.hasHood}.");
                Console.WriteLine("Your choices are: type repair to perform maintenance on one of the clothing pieces.\nType 'exit', 'e', 'q' to exit program. Leaving input empty also quits the program.");
                string input = Console.ReadLine();
                if (input == "" || check.Contains(input.ToLower()))
                {
                    { break; }
                }
                else if (input == "repair") 
                {
                    Console.WriteLine($"Which piece needs repairing? Type 1 for {ts.Name} type 2 for {pants.Name} type 3 for {hoodie.Name}.");
                    while (true)
                    {
                        string rinput = Console.ReadLine();
                        if (rinput == "1")
                        {
                            ts.Repair();
                            Console.WriteLine($"{ts.Name} repaired!");
                            System.Threading.Thread.Sleep(1000);
                            { break; }
                        }
                        else if (rinput == "2") 
                        { 
                            pants.Repair();
                            Console.WriteLine($"{pants.Name} repaired!");
                            System.Threading.Thread.Sleep(1000);
                            { break; }
                        }
                        else if (rinput == "3")
                        {
                            hoodie.Repair();
                            Console.WriteLine($"{hoodie.Name} repaired!");
                            System.Threading.Thread.Sleep(1000);
                            { break; }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice, try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option, try again.");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}