namespace Elevator_Program
{
    public class Elevator
    {
        private Elevator() 
        {
            MinFloor = 1;
            MaxFloor = 5;
            CurrentFloor = MinFloor;
        }
        public Elevator(int minF, int maxF)
        {
            MinFloor = minF;
            MaxFloor = maxF;
            CurrentFloor = MinFloor;
        }
        private int MinFloor { get; }
        private int MaxFloor { get; }
        public int CurrentFloor { get; set; }

        public bool GoTo(int floor, out string message)
        {
            if (floor >= MinFloor && floor <= MaxFloor) 
            { 
                CurrentFloor = floor;
                message = $"Going to floor {floor}";
                return true ;
            }
            if (floor < MinFloor || floor > MaxFloor )
            {
                message = $"There is no floor {floor}";
                return false;
            }
            else
            {
                message = "Unexpected event? Something went wrong.";
                return false;
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Elevator Ele = new Elevator(1, 5);
            string[] check = { "exit", "q", "e", "quit" };
            Console.WriteLine("███████ ██      ███████ ██    ██  █████  ████████  ██████  ██████  \r\n██      ██      ██      ██    ██ ██   ██    ██    ██    ██ ██   ██ \r\n█████   ██      █████   ██    ██ ███████    ██    ██    ██ ██████  \r\n██      ██      ██       ██  ██  ██   ██    ██    ██    ██ ██   ██ \r\n███████ ███████ ███████   ████   ██   ██    ██     ██████  ██   ██ \r\n                                                                   ");
            while (true)
            {
                Console.WriteLine($"Elevator is now in floor: {Ele.CurrentFloor}");
                Console.WriteLine("Give a new floor number (1-5)");
                string input = Console.ReadLine();
                string message = "";
                if (check.Contains(input.ToLower()))
                {
                    { break; }
                }
                else
                {
                    if (int.TryParse(input, out int value))
                    {
                        Ele.GoTo(value, out message);
                        Console.WriteLine(message);
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Please input a number or type exit, e or q to exit the program.");
                    }
                }
            }
        }
    }
}