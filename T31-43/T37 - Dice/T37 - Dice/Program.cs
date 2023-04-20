using System;

namespace Dice_Throwing
{
    class Dice
    {
        private Random random;

        public Dice()
        {
            random = new Random();
        }

        public int Roll()
        {
            return random.Next(1, 7);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();

            // Roll the dice once
            int result = dice.Roll();
            Console.WriteLine($"Dice, one test throw value is {result}\n");

            // Roll the dice multiple times
            Console.Write("How many times you want to throw a dice: ");
            int throws = int.Parse(Console.ReadLine());

            int sum = 0;
            int[] counts = new int[7]; // counts[0] is unused

            for (int i = 0; i < throws; i++)
            {
                int roll = dice.Roll();
                sum += roll;
                counts[roll]++;
            }

            double average = (double)sum / throws;
            Console.WriteLine($"\nDice is now thrown {throws} times");
            Console.WriteLine($"- average is {average:F4}");

            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine($"- {i} count is {counts[i]}");
            }

            Console.ReadLine(); // Wait for user to press enter
        }
    }
}