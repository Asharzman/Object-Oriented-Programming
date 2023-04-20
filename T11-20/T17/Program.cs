using System.Reflection;

namespace Radio_Program
{
    public class Radio
    {
        private Radio()
        {
            State = false;
            Power = 0;
            MinVolume = 0;
            MaxVolume = 9;
            Volume = 0;
            MinFreq = 2000.0;
            MaxFreq = 26000.0;
            Frequency = 0;
        }
        public Radio(bool state, float power, int volume, double frequency)
        {
            State = state;
            Power = power;
            Volume = volume;
            MinVolume = 0;
            MaxVolume = 9;
            Frequency = frequency;
            MinFreq = 2000.0;
            MaxFreq = 26000.0;
        }
        public bool State { get; set; }
        public float Power { get; set; }
        public int MinVolume { get; }
        public int MaxVolume { get; }
        public int Volume { get; set; }
        public double MinFreq { get; }
        public double MaxFreq { get; }
        public double Frequency { get; set; }
        public override string ToString()
        {
            return $"Radio on: {State}\nPower(W): {Power}\nVolume: {Volume}\nFrequency: {Frequency}";
        }
    }
    public class Radio_Operator
    {
        ConsoleKeyInfo key;
        Radio rad = new Radio(false, 75, 0, 1200.0);
        public void OperateRadio()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ \r\n▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌\r\n▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌\r\n▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌    ▐░▌     ▐░▌       ▐░▌\r\n▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌    ▐░▌     ▐░▌       ▐░▌\r\n▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌    ▐░▌     ▐░▌       ▐░▌\r\n▐░█▀▀▀▀█░█▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌    ▐░▌     ▐░▌       ▐░▌\r\n▐░▌     ▐░▌  ▐░▌       ▐░▌▐░▌       ▐░▌    ▐░▌     ▐░▌       ▐░▌\r\n▐░▌      ▐░▌ ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▄▄▄▄█░█▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌\r\n▐░▌       ▐░▌▐░▌       ▐░▌▐░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌\r\n ▀         ▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀ \r\n                                                                ");
                Console.WriteLine("Controls: Press ESC, Q or E to exit program.\nPress R to toggle power.\nPress Up and Down arrows to change volume (needs power).\nPress F to change frequency (needs power).");
                Console.WriteLine(rad.ToString());
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q || key.Key == ConsoleKey.E)
                { break; }
                else if (key.Key == ConsoleKey.R)
                {
                    TogglePower();
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    VolumeSlider(1);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    VolumeSlider(-1);
                }
                else if (key.Key == ConsoleKey.F)
                {
                    TuneRadio();
                }
            }
        }
    
        public void TogglePower()
        {
            rad.State = !rad.State;
            Console.WriteLine($"\nRadio is now on: {rad.State}");
            System.Threading.Thread.Sleep( 1000 );
        }
        public void VolumeSlider(int value)
        {
            if (rad.State == true)
            {
                if ((rad.Volume + value) >= rad.MinVolume && (rad.Volume + value) <= rad.MaxVolume )
                {
                    rad.Volume = rad.Volume + value;
                }
            }
            else
            {
                Console.WriteLine("This setting cannot be changed until radio is powered.");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }
        public void TuneRadio()
        {
            if (rad.State == true)
            {
                Console.WriteLine("Input desired frequency:");
                while (true)
                {
                    string newfreq = Console.ReadLine();
                    bool freqdouble = double.TryParse(newfreq, out double newfreqvalue);
                    if (freqdouble == true)
                    {
                        if (newfreqvalue >= rad.MinFreq && newfreqvalue <= rad.MaxFreq)
                        {
                            rad.Frequency = newfreqvalue;
                            Console.Clear();
                            { break; }
                        }
                        else if (newfreqvalue < rad.MinFreq)
                        {
                            Console.WriteLine($"New frequency cannot be lower than {rad.MinFreq}");
                        }
                        else if (newfreqvalue > rad.MaxFreq)
                        {
                            Console.WriteLine($"New frequency cannot be higher than {rad.MaxFreq}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please give an valid numerical value.");
                    }
                }
            }
            else
            {
                Console.WriteLine("This setting cannot be changed until radio is powered.");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Radio_Operator funker = new Radio_Operator();
            funker.OperateRadio();
        }
    }
}