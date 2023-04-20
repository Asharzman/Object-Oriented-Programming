using System.Net.Sockets;

public class Television
{
    public class TV
    {
        public int channel = 1;
        private const int minChannel = 1;
        private const int maxChannel = 99;
        public int volume = 10;
        private const int minVolume = 0;
        private const int maxVolume = 50;
        public bool signal = false;
        private string content = string.Empty;

        public int GetChannel()
        {
            return channel;
        }
        public int GetVolume() 
        { 
            return volume;
        }
        public bool GetSignal(int value)
        {
            if (value == 1)
            {
                signal = true;
                return signal;
            }
            else if (value == 69)
            {
                signal = true;
                return signal;
            }
            else
            {
                signal = false;
                return signal;
            }
        }
        public string GetContent(int value)
        {
            if (value == 1)
            {
                string content = "Thank you for choosing De-Luxe TV! In this short info we will instruct you how to use your new TV! \nYou can switch between channels using the left and right arrow keys (left arrow key = channel down, right arrow key = channel up)\nUsing the up and down arrow keys lets you control the volume level\n(Arrow key up = volume up, Arrow key down = volume down). \nThe TV will inform you if the channel you chose has no signal. \nTo turn off the TV, press escape.";
                return content;
            }
            else if (value == 69)
            {
                string content = "Please verify your age before viewing this channel by calling 1-800-CARWARRANTIES, thank you.";
                return content;
            }
            else
            {
                return "";
            }
        }
        public int SetChannel(int value)
        {
            if (value > 0)
            {
                if (channel + value > maxChannel)
                {
                    channel = minChannel;
                    return channel;
                }
                else
                {
                    channel = channel + value;
                    return channel;
                }
            }
            if (value < 0)
            {
                if (channel + value < minChannel)
                {
                    channel = maxChannel;
                    return channel;
                }
                else
                {
                    channel = channel + value;
                    return channel;
                }
            }
            else
            {
                return channel;
            }
        }
        public int SetVolume(int value)
        {
            if (value > 0)
            {
                if (volume + value > maxVolume)
                {
                    volume = maxVolume;
                    return volume;
                }
                else
                {
                    volume = volume + value;
                    return volume;
                }
            }
            if (value < 0)
            {
                if (volume + value < minVolume)
                {
                    volume = minVolume;
                    return volume;
                }
                else
                {
                    volume = volume + value;
                    return volume;
                }
            }
            else
            {
                return volume;
            }
        }
        public string ChannelManager(int value)
        {
            GetSignal(GetChannel());
            if (signal == false)
            {
                string header = $"CHANNEL {GetChannel()}\n/// NO SIGNAL ///";
                return header;
            }
            else
            {
                string header = $"CHANNEL {GetChannel()}\n\n{GetContent(GetChannel())}";
                return header;
            }
        }
    }
    static void Main(string[] args)
    {
        TV tm = new();
        ConsoleKeyInfo key;
        while (true)
        {
            Console.Clear();
            Console.WriteLine(tm.ChannelManager(1));
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            { break; }
            else
            {
                if (key.Key == ConsoleKey.RightArrow)
                {
                    tm.SetChannel(1);
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    tm.SetChannel(-1);
                };
                if (key.Key == ConsoleKey.UpArrow)
                {
                    tm.SetVolume(1);
                    Console.WriteLine("Volume " + tm.GetVolume());
                    System.Threading.Thread.Sleep(500);
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    tm.SetVolume(-1);
                    Console.WriteLine("Volume " + tm.GetVolume());
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

    }
}