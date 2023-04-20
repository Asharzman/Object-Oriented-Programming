using System;
using System.Diagnostics;
using System.Xml.Schema;

class Tripcosts
{
    public static class Calc
    {
        public static double fuel;
        public static double cost;


        public static void calculate(double len)
        {
            Random r = new Random();
            double consuming = r.Next(6, 9);
            double fuelprice = r.Next(175, 250);
            double fuelrealprice = fuelprice / 100;
            fuel = len / 100 * consuming;
            cost = fuel * fuelrealprice;

        }

    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter distance traveled: ");
        bool Valid = false;
        int Number;
        while (Valid == false)
        {
            string Input = Console.ReadLine();
            if (int.TryParse(Input, out Number))
            {
                int distance = int.Parse(Input);
                Calc.calculate(distance);
                Console.WriteLine("Fuel consumption is " + Calc.fuel + " liters and it costs " + Calc.cost + " euros.");
                Console.ReadKey();
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, try typing in an integer.");
            }
        }
    }
}