using System.Reflection;

namespace FishRegister
{
    class Fish
    {
        public string species;
        public double length;
        public double weight;
        public string place;
        public string location;
        public string fishermanName;
    }

    class MyFishRegister
    {
        private List<Fish> fishList = new List<Fish>();

        public void AddFish(Fish fish)
        {
            fishList.Add(fish);
        }

        public void PrintAllFish()
        {
            Console.WriteLine("\n*** All fish in Fish-register: ***");
            var sortedFish = fishList;
            foreach (var fish in sortedFish)
            {
                Console.WriteLine($"\n- {fish.species} {fish.length} cm {fish.weight} kg");
                Console.WriteLine($"- place: {fish.place}");
                Console.WriteLine($"- location: {fish.location}");
                Console.WriteLine($"- Fisherman: {fish.fishermanName}");
            }

            Console.WriteLine("\n\n\nSorted register\n");

            // Sort the list of fish by weight in descending order
            var assortedFish = fishList.OrderByDescending(f => f.weight).ToList();

            Console.WriteLine("*** All fish in Fish-register: ***\n");

            // Print each fish along with its information
            foreach (var fish in assortedFish)
            {
                Console.WriteLine($"- {fish.species} {fish.length} cm {fish.weight} kg");
                Console.WriteLine($"  place: {fish.place}");
                Console.WriteLine($"  location: {fish.location}");
                Console.WriteLine($"  Fisherman: {fish.fishermanName}\n");
            }
            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }

    class MyFishApp
    {
        private MyFishRegister fishRegister = new MyFishRegister();

        public void AddFisher(string name, string phoneNumber)
        {
            Console.WriteLine("A new Fisherman added to Fish-register:");
            Console.WriteLine($" - Fisherman: {name} Phone: {phoneNumber}");
        }

        public void AddFish(string fishermanName, string species, double length, double weight, string place, string location)
        {
            Console.WriteLine($"\nFisher: {fishermanName} got a new fish");
            Console.WriteLine($" - species: {species} {length} cm {weight} kg");
            Console.WriteLine($" - place: {place}");
            Console.WriteLine($" - location: {location}");

            Fish fish = new Fish()
            {
                species = species,
                length = length,
                weight = weight,
                place = place,
                location = location,
                fishermanName = fishermanName
            };
            fishRegister.AddFish(fish);
        }

        public void PrintAllFish()
        {
            fishRegister.PrintAllFish();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyFishApp app = new MyFishApp();
            app.AddFisher("Kirsi Kernel", "020-12345678");
            app.AddFish("Kirsi Kernel", "pike", 120, 4.5, "The Lake of Jyväskylä", "Jyväskylä");
            app.AddFish("Kirsi Kernel", "salmon", 190, 13.2, "River Teno", "The Northern edge of Finland");
            app.AddFisher("Uolevi Kärppä", "040-98765432");
            app.AddFish("Uolevi Kärppä", "crucian carp", 20, 0.4, "The Lake of Jyväskylä", "Jyväskylä");

            app.PrintAllFish();
        }
    }
}