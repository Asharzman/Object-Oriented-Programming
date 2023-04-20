using System.Drawing;

namespace Vehicles
{
    public class Vehicle
    {
        public Vehicle() 
        {
            Type = "";
            Name = "";
            Model = "";
            ModelYear = 0;
            Color = "";
            SeatCount = 0;
            BoatType = "";
            GearWheels = false;
            GearName = "";
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public int SeatCount { get; set; }
        public string BoatType { get; set; }
        public bool GearWheels { get; set; }
        public string GearName { get; set; }


    }
    public class Vehicle_Handler
    {
        ConsoleKeyInfo key;
        string[] check = { "exit", "q", "e", "quit" };
        public List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle { Type = "Bike", Name = "Tunturi", Model = "StreetPower", ModelYear = 2010, Color = "White", SeatCount = 1, BoatType = String.Empty, GearWheels = true, GearName = "Shimano Nexus" },
            new Vehicle { Type = "Bike", Name = "Jopo", Model = "Street Model", ModelYear = 2016, Color = "Yellow", SeatCount = 1, BoatType = String.Empty, GearWheels = false, GearName = "" },
            new Vehicle { Type = "Bike", Name = "Old Bike", Model = "Rustic", ModelYear = 1950, Color = "Gray", SeatCount = 1, BoatType = String.Empty, GearWheels = false, GearName = "" },
            new Vehicle { Type = "Boat", Name = "SummerFun", Model = "S900", ModelYear = 1990, Color = "White", SeatCount = 3, BoatType = "Rowboat", GearWheels = false, GearName = "" },
            new Vehicle { Type = "Boat", Name = "Yamaha", Model = "1000", ModelYear = 2010, Color = "Red", SeatCount = 5, BoatType = "Motorboat", GearWheels = false, GearName = "" },
            new Vehicle { Type = "Car", Name = "Ford", Model = "Mondeo", ModelYear = 2011, Color = "Black", SeatCount = 5, BoatType = String.Empty, GearWheels = false, GearName = "" },
            new Vehicle { Type = "Car", Name = "Mercedes", Model = "Benz", ModelYear = 2016, Color = "Black", SeatCount = 5, BoatType = String.Empty, GearWheels = false, GearName = "" }
        };
        public void ReadData()
        {
            foreach (Vehicle veh in vehicles)
            {
                if (veh.Type == "Bike")
                {
                    if (veh.GearWheels == true)
                    {
                        Console.WriteLine($"Type: {veh.Type} Name: {veh.Name} Model: {veh.Model} Model Year: {veh.ModelYear} Color: {veh.Color} Gear Wheels: {veh.GearWheels} Gear Name: {veh.GearName}");
                    }
                    else
                    {
                        Console.WriteLine($"Type: {veh.Type} Name: {veh.Name} Model: {veh.Model} Model Year: {veh.ModelYear} Color: {veh.Color} Gear Wheels: {veh.GearWheels}");
                    }
                }
                if (veh.Type == "Boat")
                {
                    Console.WriteLine($"Type: {veh.Type} Name: {veh.Name} Model: {veh.Model} Model Year: {veh.ModelYear} Color: {veh.Color} Seat Count: {veh.SeatCount} Boat Type: {veh.BoatType}");
                }
                if (veh.Type == "Car")
                {
                    Console.WriteLine($"Type: {veh.Type} Name: {veh.Name} Model: {veh.Model} Model Year: {veh.ModelYear} Color: {veh.Color} Seat Count: {veh.SeatCount}");
                }
                else
                {
                   
                }

            }
        }
        public void EditData()
        {
            string list = "the following vehicles";
            foreach (Vehicle veh in vehicles)
            {
                list += $", {veh.Name}";
            }
            Console.WriteLine("Select which vehicle you want to edit.");
            Console.WriteLine($"Possible choices are {list}.");
            Console.WriteLine("Type 1-7 for corresponding vehicle. Type exit to return to previous menu.");
            while (true)
            {
                string input = Console.ReadLine();
                bool isint = int.TryParse(input, out int value);
                if (check.Contains(input.ToLower()))
                {
                    Console.Clear();
                    { break; }
                }
                if (isint == true)
                {
                    value = value - 1;
                    if (vehicles.ElementAtOrDefault(value) != null)
                    {
                        Console.WriteLine($"You have chosen to edit {vehicles[value].Name} details.");
                        if (vehicles[value].Type == "Bike") // Handle editing bikes
                        {
                            Console.WriteLine($"Type new name for {vehicles[value].Name}");
                            string newname = Console.ReadLine();
                            if (newname != "")
                            {
                                vehicles[value].Name = newname;
                            }
                            Console.WriteLine($"Type new model for {vehicles[value].Name}");
                            string newmodel = Console.ReadLine();
                            if (newmodel != "")
                            {
                                vehicles[value].Model = newmodel;
                            }
                            Console.WriteLine($"Type new model year for {vehicles[value].Name}.");
                            while (true)
                            {
                                string newmyear = Console.ReadLine();
                                bool myearint = int.TryParse(newmyear, out int newmyearvale);
                                if (myearint == true)
                                {
                                    vehicles[value].ModelYear = newmyearvale;
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Please give year as an integer.");
                                }
                            }
                            Console.WriteLine($"Type new color for {vehicles[value].Name}");
                            string newcolor = Console.ReadLine();
                            if (newcolor != "")
                            {
                                vehicles[value].Color = newcolor;
                            }
                            Console.WriteLine($"Does the bike have gears? y/n");
                            key = Console.ReadKey();
                            while (true)
                            {
                                if (key.Key == ConsoleKey.Y)
                                {
                                    vehicles[value].GearWheels = true;
                                    Console.WriteLine("Please give name for gear system.");
                                    string newgearname = Console.ReadLine();
                                    if (newgearname != "")
                                    {
                                        vehicles[value].GearName = newgearname;
                                    }
                                }
                                if (key.Key == ConsoleKey.N)
                                {
                                    vehicles[value].GearWheels = false;
                                    vehicles[value].GearName = "";
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Try again.");
                                }
                            }
                            Console.WriteLine($"Successfully finished editing {vehicles[value].Name}'s details!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            { break; }
                        }
                        if (vehicles[value].Type == "Car") // Handle editing cars
                        {
                            Console.WriteLine($"Type new name for {vehicles[value].Name}");
                            string newname = Console.ReadLine();
                            if (newname != "")
                            {
                                vehicles[value].Name = newname;
                            }
                            Console.WriteLine($"Type new model for {vehicles[value].Name}");
                            string newmodel = Console.ReadLine();
                            if (newmodel != "")
                            {
                                vehicles[value].Model = newmodel;
                            }
                            Console.WriteLine($"Type new model year for {vehicles[value].Name}.");
                            while (true)
                            {
                                string newmyear = Console.ReadLine();
                                bool myearint = int.TryParse(newmyear, out int newmyearvale);
                                if (myearint == true)
                                {
                                    vehicles[value].ModelYear = newmyearvale;
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Please give year as an integer.");
                                }
                            }
                            Console.WriteLine($"Type new color for {vehicles[value].Name}");
                            string newcolor = Console.ReadLine();
                            if (newcolor != "")
                            {
                                vehicles[value].Color = newcolor;
                            }
                            Console.WriteLine($"Type new seat amount for {vehicles[value].Name}.");
                            while (true)
                            {
                                string newseats = Console.ReadLine();
                                bool seatint = int.TryParse(newseats, out int newseatvale);
                                if (seatint == true)
                                {
                                    vehicles[value].SeatCount = newseatvale;
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Please give seats as an integer.");
                                }
                            }
                            Console.WriteLine($"Successfully finished editing {vehicles[value].Name}'s details!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            { break; }
                        }
                        if (vehicles[value].Type == "Boat") // Handle editing boats
                        {
                            Console.WriteLine($"Type new name for {vehicles[value].Name}");
                            string newname = Console.ReadLine();
                            if (newname != "")
                            {
                                vehicles[value].Name = newname;
                            }
                            Console.WriteLine($"Type new model for {vehicles[value].Name}");
                            string newmodel = Console.ReadLine();
                            if (newmodel != "")
                            {
                                vehicles[value].Model = newmodel;
                            }
                            Console.WriteLine($"Type new model year for {vehicles[value].Name}.");
                            while (true)
                            {
                                string newmyear = Console.ReadLine();
                                bool myearint = int.TryParse(newmyear, out int newmyearvale);
                                if (myearint == true)
                                {
                                    vehicles[value].ModelYear = newmyearvale;
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Please give year as an integer.");
                                }
                            }
                            Console.WriteLine($"Type new color for {vehicles[value].Name}");
                            string newcolor = Console.ReadLine();
                            if (newcolor != "")
                            {
                                vehicles[value].Color = newcolor;
                            }
                            Console.WriteLine($"Type new seat amount for {vehicles[value].Name}.");
                            while (true)
                            {
                                string newseats = Console.ReadLine();
                                bool seatint = int.TryParse(newseats, out int newseatvale);
                                if (seatint == true)
                                {
                                    vehicles[value].SeatCount = newseatvale;
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Please give seats as an integer.");
                                }
                            }
                            Console.WriteLine($"Type new boat type for {vehicles[value].Name}");
                            string newbtype = Console.ReadLine();
                            if (newbtype != "")
                            {
                                vehicles[value].BoatType = newbtype;
                            }
                            Console.WriteLine($"Successfully finished editing {vehicles[value].Name}'s details!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            { break; }
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no vehicle assigned to your chosen number. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle_Handler handler = new Vehicle_Handler();
            string[] check = { "exit", "q", "e", "quit" };
            while (true)
            {
                Console.WriteLine("888     888          888      d8b          888                   \r\n888     888          888      Y8P          888                   \r\n888     888          888                   888                   \r\nY88b   d88P  .d88b.  88888b.  888  .d8888b 888  .d88b.  .d8888b  \r\n Y88b d88P  d8P  Y8b 888 \"88b 888 d88P\"    888 d8P  Y8b 88K      \r\n  Y88o88P   88888888 888  888 888 888      888 88888888 \"Y8888b. \r\n   Y888P    Y8b.     888  888 888 Y88b.    888 Y8b.          X88 \r\n    Y8P      \"Y8888  888  888 888  \"Y8888P 888  \"Y8888   88888P' \r\n                                                                 ");
                Console.WriteLine("Current vehicles:");
                handler.ReadData();
                Console.WriteLine("\nCurrent options:");
                Console.WriteLine("Type 1 to access vehicle editor. Type 'exit', 'q' 'e' or 'quit' to exit program.");
                string input = Console.ReadLine();
                if (check.Contains(input.ToLower()))
                {
                    { break; }
                }
                if (input == "1")
                {
                    handler.EditData();
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
    }
}