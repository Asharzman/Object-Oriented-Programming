using System;
using System.Collections.Generic;

namespace Vehicle_Two
{

    public class Tire
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string TireSize { get; set; }

        public Tire(string manufacturer, string model, string tireSize)
        {
            Manufacturer = manufacturer;
            Model = model;
            TireSize = tireSize;
        }
    }

    public class Vehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public List<Tire> Tires { get; set; }

        public Vehicle(string name, string model)
        {
            Name = name;
            Model = model;
            Tires = new List<Tire>();
        }

        public void AddTire(Tire tire)
        {
            Tires.Add(tire);
            Console.WriteLine($"Tire {tire.Manufacturer} added to vehicle {Name}");
        }

        public void PrintTires()
        {
            Console.WriteLine($"Vehicle Name: {Name} Model: {Model} has tires:");
            foreach (var tire in Tires)
            {
                Console.WriteLine($"-Name: {tire.Manufacturer} Model: {tire.Model} TireSize: {tire.TireSize}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle porsche = new Vehicle("Porsche", "911");
            Tire porscheTire = new Tire("Nokia", "Hakkapeliitta", "205R16");
            Console.WriteLine(" _   _      _     _      _        _____ _               \r\n| | | |    | |   (_)    | |      |_   _(_)              \r\n| | | | ___| |__  _  ___| | ___    | |  _ _ __ ___  ___ \r\n| | | |/ _ \\ '_ \\| |/ __| |/ _ \\   | | | | '__/ _ \\/ __|\r\n\\ \\_/ /  __/ | | | | (__| |  __/   | | | | | |  __/\\__ \\\r\n \\___/ \\___|_| |_|_|\\___|_|\\___|   \\_/ |_|_|  \\___||___/\r\n                                                        ");
            porsche.AddTire(porscheTire);
            porsche.AddTire(porscheTire);
            porsche.AddTire(porscheTire);
            porsche.AddTire(porscheTire);
            porsche.PrintTires();

            Vehicle ducati = new Vehicle("Ducati", "Diavel");
            Tire ducatiTire = new Tire("MIC", "Pilot", "160R17");
            ducati.AddTire(ducatiTire);
            ducati.AddTire(new Tire("MIC", "Pilot", "140R16"));
            ducati.PrintTires();
            Console.WriteLine("\nPress any key to exit program.");
            Console.ReadKey();
        }
    }
}