namespace Student_Goods
{
    public class School_Property
    {
        private string _category = "School";
        public string category => _category;
    }
    public class CD
    {
        private string _category = "CD";
        public string category => _category;
    }
    public class Bluray
    {
        private string _category = "Bluray";
        public string category => _category;
    }
    public class Book : School_Property
    {
        public string name = "Book";
    }
    public class MusicCD : CD
    {
        public string name = "Music";
    }
    public class ProgramCD : CD
    {
        public string name = "Program";
    }
    public class StarWars : Bluray
    {
        public string name = "Star Wars Movie";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Book sb = new Book();
            MusicCD mcd = new MusicCD();
            ProgramCD pcd = new ProgramCD();
            StarWars stars = new StarWars();
            void ShowShelf()
            {
                Console.WriteLine("On the shelf there are:");
                Console.WriteLine($"{sb.category} {sb.name}");
                Console.WriteLine($"{mcd.name} {mcd.category}");
                Console.WriteLine($"{pcd.name} {pcd.category}");
                Console.WriteLine($"{stars.name} {stars.category}");
            }
            Console.WriteLine("   _____ _             _            _   _        _____ _          _  __ \r\n  / ____| |           | |          | | ( )      / ____| |        | |/ _|\r\n | (___ | |_ _   _  __| | ___ _ __ | |_|/ ___  | (___ | |__   ___| | |_ \r\n  \\___ \\| __| | | |/ _` |/ _ \\ '_ \\| __| / __|  \\___ \\| '_ \\ / _ \\ |  _|\r\n  ____) | |_| |_| | (_| |  __/ | | | |_  \\__ \\  ____) | | | |  __/ | |  \r\n |_____/ \\__|\\__,_|\\__,_|\\___|_| |_|\\__| |___/ |_____/|_| |_|\\___|_|_|  \r\n                                                                        ");
            Console.WriteLine("To look onto the shelf, press Enter.");
            while (true)
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q)
                { break; }
                else
                {
                    if (key.Key == ConsoleKey.Enter)
                    {
                        ShowShelf();
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option.");
                    }
                }
            }
        }
    }
}