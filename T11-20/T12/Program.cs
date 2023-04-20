namespace Tank_Program
{
    public class Tank
    {
        private Tank()
        {
            Name = "";
            Type = "";
            CrewNumber = 4;
            Speed = 0;
            SpeedMax = 100;
        }
        public Tank(string name, string type, int crewnum, float speed)
        {
            Name = name;
            Type = type;
            CrewNumber = crewnum;
            Speed = speed;
            SpeedMax = 100;
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int CrewNumber { get; set; }
        public float Speed { get; set; }
        public float SpeedMax { get; }
        public void AccelerateTo(int value)
        {
            float calc = Speed + (value - Speed);
            if (calc <= SpeedMax)
            {
                Speed = calc;
            }
        }
        public void SlowTo(int value)
        {
            if (value + Speed >= 0)
            {
                float res = Speed - value;
                Speed = Speed - res;
            }
        }
        public string ShowStatus()
        {
            return $"Name: {Name}\nType: {Type}\nCrew: {CrewNumber}\nSpeed: {Speed}";
        }

    }
    public class Tank_Assembly
    {
        Tank tonk = new Tank("Baneblade", "Recon Tank", 4, 50);
        public void TestTank()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("________________ _       _          _______________________         _       _______________________ _______ \r\n\\__   __(  ___  ( (    /| \\    /\\  (  ____ \\__   __(       |\\     /( \\     (  ___  \\__   __(  ___  (  ____ )\r\n   ) (  | (   ) |  \\  ( |  \\  / /  | (    \\/  ) (  | () () | )   ( | (     | (   ) |  ) (  | (   ) | (    )|\r\n   | |  | (___) |   \\ | |  (_/ /   | (_____   | |  | || || | |   | | |     | (___) |  | |  | |   | | (____)|\r\n   | |  |  ___  | (\\ \\) |   _ (    (_____  )  | |  | |(_)| | |   | | |     |  ___  |  | |  | |   | |     __)\r\n   | |  | (   ) | | \\   |  ( \\ \\         ) |  | |  | |   | | |   | | |     | (   ) |  | |  | |   | | (\\ (   \r\n   | |  | )   ( | )  \\  |  /  \\ \\  /\\____) ___) (__| )   ( | (___) | (____/| )   ( |  | |  | (___) | ) \\ \\__\r\n   )_(  |/     \\|/    )_|_/    \\/  \\_______\\_______|/     \\(_______(_______|/     \\|  )_(  (_______|/   \\__/\r\n                                                                                                            ");
                Console.WriteLine(tonk.ShowStatus());
                Console.WriteLine("Choose your option. Type 1 to change name, type 2 to change tank's type, type 3 to change crew amount, type 4 change speed, type exit, e, or q to exit.");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    while (true)
                    {
                        Console.WriteLine("Input new tank name.");
                        string newname = Console.ReadLine();
                        if (newname == "")
                        {
                            Console.WriteLine("No changes made.");
                            System.Threading.Thread.Sleep(500);
                            { break; }
                        }
                        else
                        {
                            tonk.Name = newname;
                            { break; }
                        }
                    }
                }
                if (input == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("Input new tank type.");
                        string newtype = Console.ReadLine();
                        if (newtype == "")
                        {
                            Console.WriteLine("No changes made.");
                            System.Threading.Thread.Sleep(500);
                            { break; }
                        }
                        else
                        {
                            tonk.Type = newtype;
                            { break; }
                        }
                    }
                }
                if (input == "3")
                {
                    while (true)
                    {
                        Console.WriteLine("Input new tank crew amount (min is 2 and max is 6).");
                        string value = Console.ReadLine();
                        if (value == "")
                        {
                            Console.WriteLine("No changes made.");
                            System.Threading.Thread.Sleep(500);
                            { break; }
                        }
                        else
                        {
                            int.TryParse(value, out int result);
                            if (result >= 2 && result <= 6)
                            {
                                tonk.CrewNumber = result;
                                { break; }
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount.");
                                System.Threading.Thread.Sleep(500);
                                break;
                            }
                        }
                    }
                }
                if (input == "4")
                {
                    while (true)
                    {
                        Console.WriteLine("Input new tank speed (min is 0 max is 100).");
                        string value = Console.ReadLine();
                        if (value == "")
                        {
                            Console.WriteLine("No changes made.");
                            System.Threading.Thread.Sleep(500);
                            { break; }
                        }
                        else
                        {
                            bool asd = int.TryParse(value, out int result);
                            if (result > tonk.Speed && result <= 100 && asd == true)
                            {
                                tonk.AccelerateTo(result);
                                Console.WriteLine("Accelerated.");
                                System.Threading.Thread.Sleep(500);
                                { break; }
                            }
                            if (result < tonk.Speed && result >= 0 && asd == true)
                            {
                                tonk.SlowTo(result);
                                Console.WriteLine("Deaccelerated.");
                                System.Threading.Thread.Sleep(500);
                                { break; }
                            }
                            if (result < 0 || result > 100 || asd == false)
                            {
                                Console.WriteLine("Invalid amount.");
                                System.Threading.Thread.Sleep(500);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount.");
                                System.Threading.Thread.Sleep(500);
                                break;
                            }
                        }
                    }
                }
                if (input == "e" || input == "exit" || input == "q")
                {
                    { break; }
                }
            }

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Tank_Assembly TA = new Tank_Assembly();
                TA.TestTank();
            }
        }
    }
}