using System;
using System.Collections.Generic;

namespace NewCD
{
    class Song
    {
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
    }

    class CD
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public List<Song> Songs { get; set; }

        public int NumberOfSongs
        {
            get { return Songs.Count; }
        }

        public TimeSpan TotalLength
        {
            get
            {
                TimeSpan total = TimeSpan.Zero;
                foreach (Song song in Songs)
                {
                    total += song.Length;
                }
                return total;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CD cd = new CD();
            cd.Name = "Endless Forms Most Beautiful";
            cd.Artist = "Nightwish";
            cd.Songs = new List<Song>();
            cd.Songs.Add(new Song { Name = "Shudder Before the Beautiful", Length = TimeSpan.FromMinutes(6) + TimeSpan.FromSeconds(29) });
            cd.Songs.Add(new Song { Name = "Weak Fantasy", Length = TimeSpan.FromMinutes(5) + TimeSpan.FromSeconds(23) });
            cd.Songs.Add(new Song { Name = "Elan", Length = TimeSpan.FromMinutes(4) + TimeSpan.FromSeconds(45) });
            cd.Songs.Add(new Song { Name = "Yours Is an Empty Hope", Length = TimeSpan.FromMinutes(5) + TimeSpan.FromSeconds(34) });
            cd.Songs.Add(new Song { Name = "Our Decades in the Sun", Length = TimeSpan.FromMinutes(6) + TimeSpan.FromSeconds(37) });
            cd.Songs.Add(new Song { Name = "My Walden", Length = TimeSpan.FromMinutes(4) + TimeSpan.FromSeconds(38) });
            cd.Songs.Add(new Song { Name = "Endless Forms Most Beautiful", Length = TimeSpan.FromMinutes(5) + TimeSpan.FromSeconds(7) });
            cd.Songs.Add(new Song { Name = "Edema Ruh", Length = TimeSpan.FromMinutes(5) + TimeSpan.FromSeconds(15) });
            cd.Songs.Add(new Song { Name = "Alpenglow", Length = TimeSpan.FromMinutes(4) + TimeSpan.FromSeconds(45) });
            cd.Songs.Add(new Song { Name = "The Eyes of Sharbat Gula", Length = TimeSpan.FromMinutes(6) + TimeSpan.FromSeconds(3) });
            cd.Songs.Add(new Song { Name = "The Greatest Show on Earth", Length = TimeSpan.FromMinutes(24) });

            Console.WriteLine(" _   _               ___________ \r\n| \\ | |             /  __ \\  _  \\\r\n|  \\| | _____      _| /  \\/ | | |\r\n| . ` |/ _ \\ \\ /\\ / / |   | | | |\r\n| |\\  |  __/\\ V  V /| \\__/\\ |/ / \r\n\\_| \\_/\\___| \\_/\\_/  \\____/___/  \r\n                                 ");
            Console.WriteLine("");
            Console.WriteLine($"CD Name: {cd.Name}");
            Console.WriteLine($"Artist: {cd.Artist}");
            Console.WriteLine($"Number of Songs: {cd.NumberOfSongs}");
            Console.WriteLine($"Total Length: {cd.TotalLength}");
            Console.WriteLine("\nSongs:");
            foreach (Song song in cd.Songs)
            {
                Console.WriteLine($"- {song.Name}, {song.Length}");
            }
            Console.WriteLine("Press any key to exit program.");
            Console.ReadKey();
        }
    }
}