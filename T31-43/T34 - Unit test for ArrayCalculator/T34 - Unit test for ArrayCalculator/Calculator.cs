using System;

namespace TestingArrayCalculator
{
    public class Calculator
    {
        public static double Sum(double[] array)
        {
            double sum = 0;
            foreach (double num in array)
            {
                sum += num;
            }
            return sum;
        }

        public static double Average(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Cannot calculate average of empty array.");
            }
            double sum = Sum(array);
            return sum / array.Length;
        }

        public static double Min(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Cannot find minimum of empty array.");
            }
            double min = array[0];
            foreach (double num in array)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }

        public static double Max(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Cannot find maximum of empty array.");
            }
            double max = array[0];
            foreach (double num in array)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };

            Console.WriteLine("Sum = " + Calculator.Sum(array).ToString("0.00"));
            Console.WriteLine("Ave = " + Calculator.Average(array).ToString("0.00"));
            Console.WriteLine("Min = " + Calculator.Min(array).ToString("0.00"));
            Console.WriteLine("Max = " + Calculator.Max(array).ToString("0.00"));

            Console.ReadLine();
        }
    }
}