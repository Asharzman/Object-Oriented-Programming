using System.Net.Sockets;
using System.Xml.Linq;

namespace CarSaloon
{
    public class Vehicle
    {
        private Vehicle()
        {
            Brand = "";
            Model = "";
            Speed = 0;
            Tires = 0;
        }
        public Vehicle(string br, string mdl, int spd, int tir)
        {
            Brand = br;
            Model = mdl;
            Speed = spd;
            Tires = tir;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Tires { get; set; }
        public override string ToString()
        {
            return $"Brand is {Brand} it's model is {Model}. It's speed is {Speed} and it has {Tires} tires.";
        }
        public string ShowInfo()
        {
            return $"{Brand} {Model}";
        }
    }
    public class VehicleAssembler
    {
        Vehicle vehicle = new Vehicle("Ford", "Mondeo", 180, 4);
        Vehicle vehicle2 = new Vehicle("Fiat", "Punto", 100, 4);
        ConsoleKeyInfo key;

        public string GetCarInfo(int value)
        {
            if (value == 1)
            {
                return vehicle.ShowInfo();
            }
            if (value == 2)
            {
                return vehicle2.ShowInfo();
            }
            else
            {
                return null;
            }
        }

        public void Showcase()
        {
            Console.Clear();
            Console.WriteLine("   _____  _                                              \r\n  / ____|| |                                             \r\n | (___  | |__    ___ __      __ ___  __ _  ___   ___    \r\n  \\___ \\ | '_ \\  / _ \\\\ \\ /\\ / // __|/ _` |/ __| / _ \\   \r\n  ____) || | | || (_) |\\ V  V /| (__| (_| |\\__ \\|  __/   \r\n |_____/ |_| |_| \\___/  \\_/\\_/  \\___|\\__,_||___/ \\___|   \r\n  ______  ______  ______  ______  ______  ______  ______ \r\n |______||______||______||______||______||______||______|\r\n                                                         \r\n                                                         ");
            Console.WriteLine("Welcome to car showcase! Currently we have 2 cars for you to admire.");
            Console.WriteLine("Cycle the vehicles with arrowkeys (right, left) and cycle through different data view with up and down arrow keys.");
            Console.WriteLine("Press ESCAPE to return to previous menu.");
            Console.WriteLine("////////////////////////////////////////");
            Console.WriteLine("");
            Console.WriteLine($"{vehicle.ToString()}");
            bool state = true;
            bool screen = true;
            while (true)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                { break; }
                else
                {
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        state = !state;
                    }
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        state = !state;
                    }
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        screen = !screen;
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        screen = !screen;
                    }
                }
                if (state == true && screen == true )
                {
                    Console.WriteLine(vehicle.ToString());
                }
                if (state == true && screen == false)
                {
                    Console.WriteLine(vehicle.ShowInfo());
                }
                if (state == false && screen == true )
                {
                    Console.WriteLine(vehicle2.ToString());
                }
                if (state == false && screen == false )
                {
                    Console.WriteLine(vehicle2.ShowInfo());
                }
            }
        }
        public void Tuner()
        {
            Console.Clear();
            Console.WriteLine("  _______                        \r\n |__   __|                       \r\n    | | _   _  _ __    ___  _ __ \r\n    | || | | || '_ \\  / _ \\| '__|\r\n    | || |_| || | | ||  __/| |   \r\n    |_| \\__,_||_| |_| \\___||_|   \r\n  ______  ______  ______  ______ \r\n |______||______||______||______|\r\n                                 \r\n                                 ");
            Console.WriteLine("Choose the car you want to tune.");
            Console.WriteLine($"Press 1 to tune {vehicle.Model}. Press 2 to tune {vehicle2.Model}.");
            Console.WriteLine("Press ESCAPE to return to previous menu.");
            while (true)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                { break; }
                else
                {
                    if (key.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine($"You are tuning {vehicle.ShowInfo()}.");
                        Console.WriteLine("Current properties: " + vehicle.ToString());
                        Console.WriteLine("Controls: 1 - Brand, 2 - Model, 3 - Speed, 4 - Tires");
                        key = Console.ReadKey();
                        Console.WriteLine("Choose a property to edit.");
                        if (key.Key == ConsoleKey.Escape)
                        { break; }
                        else
                        {
                            if (key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine($"Give new Brand for {vehicle.ShowInfo()}.");
                                string newbrand = Console.ReadLine();
                                if (newbrand == "")
                                {
                                    Console.WriteLine("Input is empty, no changes made.");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    { break; }
                                }
                                else
                                {
                                    Console.Write($"{vehicle.Brand} brand has changed to {newbrand}!");
                                    System.Threading.Thread.Sleep(2000);
                                    vehicle.Brand = newbrand;
                                    Console.Clear();
                                    { break; }
                                }
                            }
                            if (key.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine($"Give new Model for {vehicle.ShowInfo()}.");
                                string newmodel = Console.ReadLine();
                                if (newmodel == "")
                                {
                                    Console.WriteLine("Input is empty, no changes made.");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    { break; }
                                }
                                else
                                {
                                    Console.Write($"{vehicle.ShowInfo()} model has changed to {newmodel}!");
                                    vehicle.Model = newmodel;
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    { break; }
                                }
                            }
                            if (key.Key == ConsoleKey.D3)
                            {
                                Console.WriteLine($"Give new speed for {vehicle.ShowInfo()}.");
                                string newspeed = Console.ReadLine();
                                int number = vehicle.Speed;
                                try
                                {
                                    int test = Int32.Parse(newspeed);
                                    number = test;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("{0}: Bad Format", newspeed);
                                }
                                vehicle.Speed = number;
                                Console.Write($"{vehicle.ShowInfo()} speed has changed to {vehicle.Speed}!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                { break; }
                            }
                            if (key.Key == ConsoleKey.D4)
                            {
                                Console.WriteLine($"Give new amount of tires for {vehicle.ShowInfo()}.");
                                string newtire = Console.ReadLine();
                                int number = vehicle.Tires;
                                try
                                {
                                    int test = Int32.Parse(newtire);
                                    number = test;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("{0}: Bad Format", newtire);
                                }
                                vehicle.Tires = number;
                                Console.Write($"{vehicle.ShowInfo()}'s amount of tires has changed to {vehicle.Tires}!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                { break; }
                            }
                            
                        }
                    }
                    if (key.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine($"You are tuning {vehicle2.ShowInfo()}.");
                        Console.WriteLine("Current properties: " + vehicle2.ToString());
                        Console.WriteLine("Controls: 1 - Brand, 2 - Model, 3 - Speed, 4 - Tires");
                        key = Console.ReadKey();
                        Console.WriteLine("Choose a property to edit.");
                        if (key.Key == ConsoleKey.Escape)
                        { break; }
                        else
                        {
                            if (key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine($"Give new Brand for {vehicle2.ShowInfo()}.");
                                string newbrand = Console.ReadLine();
                                if (newbrand == "")
                                {
                                    Console.WriteLine("Input is empty, no changes made.");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    { break; }
                                }
                                else
                                {
                                    Console.Write($"{vehicle2.Brand} brand has changed to {newbrand}!");
                                    System.Threading.Thread.Sleep(2000);
                                    vehicle2.Brand = newbrand;
                                    Console.Clear();
                                    { break; }
                                }
                            }
                            if (key.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine($"Give new Model for {vehicle2.ShowInfo()}.");
                                string newmodel = Console.ReadLine();
                                if (newmodel == "")
                                {
                                    Console.WriteLine("Input is empty, no changes made.");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    { break; }
                                }
                                else
                                {
                                    Console.Write($"{vehicle2.ShowInfo()} model has changed to {newmodel}!");
                                    vehicle2.Model = newmodel;
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    { break; }
                                }
                            }
                            if (key.Key == ConsoleKey.D3)
                            {
                                Console.WriteLine($"Give new speed for {vehicle2.ShowInfo()}.");
                                string newspeed = Console.ReadLine();
                                int number = vehicle2.Speed;
                                try
                                {
                                    int test = Int32.Parse(newspeed);
                                    number = test;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("{0}: Bad Format", newspeed);
                                }
                                vehicle2.Speed = number;
                                Console.Write($"{vehicle2.ShowInfo()} speed has changed to {vehicle2.Speed}!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                { break; }
                            }
                            if (key.Key == ConsoleKey.D4)
                            {
                                Console.WriteLine($"Give new amount of tires for {vehicle2.ShowInfo()}.");
                                string newtire = Console.ReadLine();
                                int number = vehicle2.Tires;
                                try
                                {
                                    int test = Int32.Parse(newtire);
                                    number = test;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("{0}: Bad Format", newtire);
                                }
                                vehicle2.Tires = number;
                                Console.Write($"{vehicle2.ShowInfo()}'s amount of tires has changed to {vehicle2.Tires}!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                { break; }
                            }

                        }
                    }
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleAssembler VA = new();
            ConsoleKeyInfo key;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("   _____                _____         _                          \r\n  / ____|              / ____|       | |                         \r\n | |      __ _  _ __  | (___    __ _ | |  ___    ___   _ __      \r\n | |     / _` || '__|  \\___ \\  / _` || | / _ \\  / _ \\ | '_ \\     \r\n | |____| (_| || |     ____) || (_| || || (_) || (_) || | | |    \r\n  \\_____|\\__,_||_|    |_____/  \\__,_||_| \\___/  \\___/ |_| |_|    \r\n  ______  ______  ______  ______  ______  ______  ______  ______ \r\n |______||______||______||______||______||______||______||______|\r\n                                                                 \r\n                                                                 ");
                Console.WriteLine("Welcome! Choose what you want to do.");
                Console.WriteLine($"Current cars: {VA.GetCarInfo(1)} and {VA.GetCarInfo(2)}");
                Console.WriteLine("1. Showcase (To see the cars!) 2. Tuner (To tune the cars). Press ESCAPE to exit.");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                { break; }
                else
                {
                    if (key.Key == ConsoleKey.D1)
                    {
                        VA.Showcase();
                    }
                    if (key.Key == ConsoleKey.D2)
                    {
                        VA.Tuner();
                    }


                }
            }

        }
    }
}