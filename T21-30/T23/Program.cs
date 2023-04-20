using System;
using System.Collections.Generic;

namespace Queue_System
{
    public class CheckoutQueue : ICheckoutQueue
    {
        private Queue<string> queue;

        public CheckoutQueue()
        {
            queue = new Queue<string>();
        }

        public void GoToQueue(string customerName)
        {
            queue.Enqueue(customerName);
            Console.WriteLine($"{customerName} joined the queue.");
        }

        public void ExitQueue(string customerName)
        {
            if (queue.Contains(customerName))
            {
                queue = new Queue<string>(queue.Where(x => x != customerName));
                Console.WriteLine($"{customerName} exited the queue.");
            }
            else
            {
                Console.WriteLine($"{customerName} is not in the queue.");
            }
        }

        public int Length
        {
            get { return queue.Count; }
        }
    }

    public interface ICheckoutQueue
    {
        void GoToQueue(string customerName);
        void ExitQueue(string customerName);
        int Length { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICheckoutQueue checkoutQueue = new CheckoutQueue();
            Console.WriteLine(" _____                         _____           _                 \r\n|  _  |                       /  ___|         | |                \r\n| | | |_   _  ___ _   _  ___  \\ `--. _   _ ___| |_ ___ _ __ ___  \r\n| | | | | | |/ _ \\ | | |/ _ \\  `--. \\ | | / __| __/ _ \\ '_ ` _ \\ \r\n\\ \\/' / |_| |  __/ |_| |  __/ /\\__/ / |_| \\__ \\ ||  __/ | | | | |\r\n \\_/\\_\\\\__,_|\\___|\\__,_|\\___| \\____/ \\__, |___/\\__\\___|_| |_| |_|\r\n                                      __/ |                      \r\n                                     |___/                       ");
            checkoutQueue.GoToQueue("Alice");
            checkoutQueue.GoToQueue("Bob");
            checkoutQueue.GoToQueue("Charlie");

            Console.WriteLine($"Queue length: {checkoutQueue.Length}");

            checkoutQueue.ExitQueue("Bob");

            Console.WriteLine($"Queue length: {checkoutQueue.Length}");
            Console.WriteLine("\nPress any key to exit program.");
            Console.ReadKey();
        }
    }
}