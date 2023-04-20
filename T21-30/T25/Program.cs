using System;
using System.Collections.Generic;

namespace Movie_Stars
{
    class Movie
    {
        public string Name { get; }
        public int Year { get; }
        public Director Director { get; }
        public IReadOnlyList<Actor> Actors { get; }

        public Movie(string name, int year, Director director, List<Actor> actors)
        {
            Name = name;
            Year = year;
            Director = director;
            Actors = actors.AsReadOnly();
        }
    }

    class Human
    {
        public string Name { get; }
        public int BirthYear { get; }

        public Human(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }
    }

    class Actor : Human
    {
        public Actor(string name, int birthYear) : base(name, birthYear)
        {
        }
    }

    class Director : Human
    {
        public Director(string name, int birthYear) : base(name, birthYear)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            Console.WriteLine("___  ___           _        _____ _                 \r\n|  \\/  |          (_)      /  ___| |                \r\n| .  . | _____   ___  ___  \\ `--.| |_ __ _ _ __ ___ \r\n| |\\/| |/ _ \\ \\ / / |/ _ \\  `--. \\ __/ _` | '__/ __|\r\n| |  | | (_) \\ V /| |  __/ /\\__/ / || (_| | |  \\__ \\\r\n\\_|  |_/\\___/ \\_/ |_|\\___| \\____/ \\__\\__,_|_|  |___/\r\n                                                    \r\n                                                    ");

            // Create a new movie by asking for user input
            Console.WriteLine("Enter movie information:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            // Create a new director by asking for user input
            Console.WriteLine("Enter director information:");
            Console.Write("Name: ");
            string directorName = Console.ReadLine();
            Console.Write("Birth year: ");
            int directorBirthYear = int.Parse(Console.ReadLine());
            Director director = new Director(directorName, directorBirthYear);

            // Create a list of actors by asking for user input
            List<Actor> actors = new List<Actor>();
            Console.WriteLine("Enter actors information (type 'done' to finish):");
            while (true)
            {
                Console.Write("Name: ");
                string actorName = Console.ReadLine();
                if (actorName.ToLower() == "done")
                {
                    break;
                }
                Console.Write("Birth year: ");
                int actorBirthYear = int.Parse(Console.ReadLine());
                actors.Add(new Actor(actorName, actorBirthYear));
            }

            // Create the movie and add it to the list
            Movie movie = new Movie(name, year, director, actors);
            movies.Add(movie);

            // Print the movie information
            Console.WriteLine($"Movie '{movie.Name}' ({movie.Year}) directed by {movie.Director.Name} with the following actors:");
            foreach (Actor actor in movie.Actors)
            {
                Console.WriteLine($"- {actor.Name} ({actor.BirthYear})");
            }
            Console.WriteLine("\nPress any key to exit the program.");
        }
    }
}