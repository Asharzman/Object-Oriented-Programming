using System;
using System.Threading;

namespace Timer
{
    class Timer
    {
        private int seconds;
        private string notification;

        public Timer(int seconds, string notification)
        {
            this.seconds = seconds;
            this.notification = notification;
        }

        public void Start()
        {
            Console.WriteLine($"Timer set for {seconds} seconds.");

            // Sleep for the specified number of seconds
            Thread.Sleep(seconds * 1000);

            // Display notification when time is up
            Console.WriteLine(notification);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Set the timer in seconds or minutes (e.g. 30s or 5m):");
            string input = Console.ReadLine();

            // Parse the input to get the time and unit
            int time = int.Parse(input.Substring(0, input.Length - 1));
            string unit = input.Substring(input.Length - 1).ToLower();

            // Convert time to seconds if necessary
            if (unit == "m")
            {
                time *= 60;
            }

            // Create the timer and start it
            Timer timer = new Timer(time, "Wake wake, the little bird!");
            timer.Start();
        }
    }
}