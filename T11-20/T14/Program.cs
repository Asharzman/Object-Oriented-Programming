namespace Amplifier_Program
{
    public class Amp
    {
        public Amp()
        {
            MinVolume = 0;
            MaxVolume = 100;
            Volume = MinVolume;
        }
        public Amp(int audio)
        {
            MinVolume = 0;
            MaxVolume = 100;
            Volume = audio;
        }
        private int MinVolume { get; }
        private int MaxVolume { get; }
        public int Volume { get; set; }
        public void ChangeVolume(int value, out string output)
        {
            output = "";
            if (value > Volume && value >= 0)
            {
                int check = Volume - (Volume - value);
                if (value <= MaxVolume && check <= MaxVolume)
                {
                    Volume = check;
                    output = $"Volume raised to {Volume}";
                }
                else
                {
                    Volume = MaxVolume;
                    output = $"Volume cannot be higher than {MaxVolume}!\nVolume raised to the maximum.";
                }
            }
            if (value < Volume && value >= 0)
            {
                int check = Volume - (Volume - value);
                if (check >= MinVolume)
                {
                    int res = Volume - value;
                    Volume = Volume - res;
                    output = $"Volume lowered to {Volume}";
                }
                else
                {
                    Volume = MinVolume;
                    output = $"Volume cannot be lower than {MinVolume}!\nVolume lowered to the minimum.";
                }
            }
            if (value < 0) 
            {
                value = value * -1;
                int check = Volume - (Volume - value);
                if (Volume - check >= MinVolume)
                {
                    Volume = Volume - check;
                    output = $"Volume substracted by {check}, volume is now {Volume}";
                }
                else
                {
                    Volume = MinVolume;
                    output = $"Volume cannot be lowered by {check} because volume cannot go lower than {MinVolume}!\nVolume lowered to the minimum.";
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Amp amp = new Amp(25);
            string[] check = { "exit", "q", "e", "quit" };
            Console.WriteLine("  ____  ___ ___  ____        _____ ____  ___ ___  __ __  _       ____  ______   ___   ____  \r\n /    ||   |   ||    \\      / ___/|    ||   |   ||  |  || |     /    ||      | /   \\ |    \\ \r\n|  o  || _   _ ||  o  )    (   \\_  |  | | _   _ ||  |  || |    |  o  ||      ||     ||  D  )\r\n|     ||  \\_/  ||   _/      \\__  | |  | |  \\_/  ||  |  || |___ |     ||_|  |_||  O  ||    / \r\n|  _  ||   |   ||  |        /  \\ | |  | |   |   ||  :  ||     ||  _  |  |  |  |     ||    \\ \r\n|  |  ||   |   ||  |        \\    | |  | |   |   ||     ||     ||  |  |  |  |  |     ||  .  \\\r\n|__|__||___|___||__|         \\___||____||___|___| \\__,_||_____||__|__|  |__|   \\___/ |__|\\_|\r\n                                                                                            ");
            while (true)
            {
                Console.WriteLine($"Amp's volume is now {amp.Volume}");
                Console.WriteLine("Give a new volume 0-100. Negative values substracts volume by given amount.\nWrite 'exit', 'q', 'e' or 'quit' to exit the program.");
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
                        amp.ChangeVolume(value, out message);
                        Console.WriteLine(message);
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Please input a number or type 'exit', 'e' or 'q' to exit the program.");
                    }
                }
            }
        }
    }
}