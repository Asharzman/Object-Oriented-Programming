using System;
using System.Collections.Generic;

namespace SMLeague
{
    class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GameLocation { get; set; }
        public int Number { get; set; }
    }

    class Team
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
        public List<Player> Players { get; set; }

        public Team(string team)
        {
            Name = team;
            Hometown = "Unknown"; // You can set the hometown of the team here
            Players = new List<Player>();

            // Add some sample players for the team
            switch (team)
            {
                case "JYP":
                    Players.Add(new Player { FirstName = "Ossi", LastName = "Louhivaara", GameLocation = "Forward", Number = 26 });
                    Players.Add(new Player { FirstName = "Antti", LastName = "Suomela", GameLocation = "Forward", Number = 24 });
                    Players.Add(new Player { FirstName = "Mikko", LastName = "Kalteva", GameLocation = "Defenseman", Number = 7 });
                    break;
                case "Kalpa":
                    Players.Add(new Player { FirstName = "Eetu", LastName = "Luostarinen", GameLocation = "Forward", Number = 19 });
                    Players.Add(new Player { FirstName = "Anrei", LastName = "Hakulinen", GameLocation = "Forward", Number = 21 });
                    Players.Add(new Player { FirstName = "Kim", LastName = "Nousiainen", GameLocation = "Defenseman", Number = 47 });
                    break;
                case "Tappara":
                    Players.Add(new Player { FirstName = "Kristian", LastName = "Kuusela", GameLocation = "Forward", Number = 71 });
                    Players.Add(new Player { FirstName = "Juhani", LastName = "Jasu", GameLocation = "Forward", Number = 27 });
                    Players.Add(new Player { FirstName = "Ben", LastName = "Blood", GameLocation = "Defenseman", Number = 24 });
                    break;
                // Add more cases for other teams
                default:
                    Console.WriteLine("Unknown team: " + team);
                    break;
            }
        }
    }

    class Program
    {
        static List<Team> teams = new List<Team>();

        static void Main(string[] args)
        {
            // Add some teams to the list
            teams.Add(new Team("JYP"));
            teams.Add(new Team("Kalpa"));
            teams.Add(new Team("Tappara"));

            while (true)
            {
                Console.WriteLine(" ________  ___  _     _ _             \r\n/  ___|  \\/  | | |   (_|_)            \r\n\\ `--.| .  . | | |    _ _  __ _  __ _ \r\n `--. \\ |\\/| | | |   | | |/ _` |/ _` |\r\n/\\__/ / |  | | | |___| | | (_| | (_| |\r\n\\____/\\_|  |_/ \\_____/_|_|\\__, |\\__,_|\r\n                           __/ |      \r\n                          |___/       ");
                Console.WriteLine($"Current teams: JYP, Kalpa, Tappara.");
                Console.WriteLine("Enter a command (add, delete, list, quit):");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        AddPlayer();
                        break;
                    case "delete":
                        DeletePlayer();
                        break;
                    case "list":
                        ListPlayers();
                        break;
                    case "quit":
                        return;
                    default:
                        Console.WriteLine("Unknown command: " + command);
                        break;
                }
            }
        }

        static void AddPlayer()
        {
            Console.WriteLine("Enter the team name:");
            string teamName = Console.ReadLine();
            Team team = teams.Find(t => t.Name == teamName);
            if (team == null)
            {
                Console.WriteLine("Unknown team: " + teamName);
                return;
            }

            Console.WriteLine("Enter the player's first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the player's last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the player's game location:");
            string gameLocation = Console.ReadLine();
            Console.WriteLine("Enter the player's number:");
            int number = int.Parse(Console.ReadLine());

            Player player = new Player { FirstName = firstName, LastName = lastName, GameLocation = gameLocation, Number = number };
            team.Players.Add(player);

            Console.WriteLine("Player added to team " + teamName);
        }

        static void DeletePlayer()
        {
            Console.WriteLine("Enter the team name:");
            string teamName = Console.ReadLine();
            Team team = teams.Find(t => t.Name == teamName);
            if (team == null)
            {
                Console.WriteLine("Unknown team: " + teamName);
                return;
            }

            Console.WriteLine("Enter the player's number:");
            int number = int.Parse(Console.ReadLine());
            Player player = team.Players.Find(p => p.Number == number);
            if (player == null)
            {
                Console.WriteLine("Unknown player number: " + number);
                return;
            }

            team.Players.Remove(player);
            Console.WriteLine("Player removed from team " + teamName);
        }

        static void ListPlayers()
        {
            Console.WriteLine("Enter the team name:");
            string teamName = Console.ReadLine();
            Team team = teams.Find(t => t.Name == teamName);
            if (team == null)
            {
                Console.WriteLine("Unknown team: " + teamName);
                return;
            }

            Console.WriteLine("Players for team " + teamName + ":");
            foreach (Player player in team.Players)
            {
                Console.WriteLine(player.FirstName + " " + player.LastName + ", " + player.GameLocation + ", #" + player.Number);
            }
        }
    }
}