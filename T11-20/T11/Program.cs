using System.Reflection;

namespace CDDisplay
{
    public class CD
    {
        private CD()
        {
            Artist = "";
            Name = "";
            Genre = "";
            Price = "";
            Songs = "";
        }
        public CD(string artist, string name, string genre, string price, string songs)
        {
            Artist = artist;
            Name = name;
            Genre = genre;
            Price = price;
            Songs = songs;
        }
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
        public string Songs { get; set; }
        public override string ToString()
        {
            return $"-Artist: {Artist}\n-Album: {Name}\n-Genre: {Genre}\n-Price: {Price}\nSongs:\n{Songs}";
        }
    }
    public class CDAssembler
    {
        public static string ArrayToString(string[] arr)
        {
            int i = 1;
            var result = string.Empty;
            foreach (var item in arr)
            {
                result += "--- Name: " + i + " " + item + "\n";
                i++;
            }
            return result;
        }
        static string[] cd1songs = { "Ghostbusters - 00:59", "Ghost buster - 00:50", "Ghostbusterz - 00:59", "Ghost-Boster - 01:21", "Ghastbistin - 00:47", "Ghostbusterss - 01:03", "Ghustbusters - 00:25", "Gostbostr - 01:00", "Ghostabusta - 00:53", "Ghooooostbuster - 00:59", "Ghostingbust - 00:46", "Ghostbatista - 01:04", "Gheestobesto - 00:59", "Ghastbasters - 01:20", "Ghestbest - 00:48", "Ghosttbusters - 00:19", "Ghost Bast - 01:15", "Ghoostbuusters - 01:05", "Ghosterboster - 00:28", "Ghstbstrs - 00:50", "Ghost Bus- Ters - 01:00", "Ghost Boston - 01:24", "Ghostboster - 00:27", "Ghost Bologna - 00:48", "Ghost Bapilogue - 00:04" };
        static string songs1 = ArrayToString(cd1songs);
        CD cd1 = new CD("Vargskelethor", "Super Ghostbusters", "Groove", "19.99", songs1);
        public string GetCDInfo()
        {
            return cd1.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CDAssembler cda = new CDAssembler();
            Console.WriteLine("CD Info Display Program v0.01");
            Console.WriteLine("Press Enter to show CD info. Press ESC to exit.");
            int i = 0;
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                { break; }
                else
                {
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine(cda.GetCDInfo());
                    }
                }
            }
        }
    }
}