using System;
using System.Collections.Generic;
using System.IO;

namespace SMLeagueExport
{
    class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GameLocation { get; set; }
        public int Number { get; set; }

        public Player(string firstName, string lastName, string gameLocation, int number)
        {
            FirstName = firstName;
            LastName = lastName;
            GameLocation = gameLocation;
            Number = number;
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
        public List<Player> Players { get; set; }

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();

            if (name == "JYP")
            {
                Hometown = "Jyväskylä";
                Players.Add(new Player("Jarkko", "Immonen", "center", 26));
                Players.Add(new Player("Brad", "Lambert", "forward", 16));
            }
            else if (name == "KalPa")
            {
                Hometown = "Kuopio";
                Players.Add(new Player("Eetu", "Laurikainen", "goalie", 33));
                Players.Add(new Player("Anrei", "Hakulinen", "forward", 26));
            }
            // add more teams and players here
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public void ListPlayers()
        {
            Console.WriteLine("Name\tLast Name\tGame Location\tNumber");
            foreach (Player player in Players)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", player.FirstName, player.LastName, player.GameLocation, player.Number);
            }
        }

        public void SavePlayersToCsv()
        {
            string fileName = Name + ".csv";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Player player in Players)
                {
                    writer.WriteLine("{0};{1};{2};{3}", player.FirstName, player.LastName, player.GameLocation, player.Number);
                }
            }
            Console.WriteLine("Players saved to file {0}", fileName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team("JYP"));
            teams.Add(new Team("KalPa"));
            // add more teams here

            Console.WriteLine("SMLiiga team manager");
            Console.WriteLine("Available commands: add, remove, list, save, quit");

            while (true)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine().ToLower();
                if (command == "add")
                {
                    Console.Write("Enter team name: ");
                    string teamName = Console.ReadLine();
                    Team team = teams.Find(t => t.Name == teamName);
                    if (team == null)
                    {
                        team = new Team(teamName);
                        teams.Add(team);
                    }
                    Console.Write("Enter player first name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter player last name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter player game location: ");
                    string gameLocation = Console.ReadLine();
                    Console.Write("Enter player number: ");
                    int number = int.Parse(Console.ReadLine());
                    team.AddPlayer(new Player(firstName, lastName, gameLocation, number));
                    Console.WriteLine("Player added to team.");
                }
                else if (command == "remove")
                {
                    Console.Write("Enter team name: ");
                    string teamName = Console.ReadLine();
                    Team team = teams.Find(t => t.Name == teamName);
                    if (team != null)
                    {
                        Console.Write("Enter player number: ");
                        int number = int.Parse(Console.ReadLine());
                        Player player = team.Players.Find(p => p.Number == number);
                        if (player != null)
                        {
                            team.RemovePlayer(player);
                            Console.WriteLine("Player removed from team");
                        }
                        else
                        {
                            Console.WriteLine("Player not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Team not found");
                    }
                }
                else if (command == "list")
                {
                    Console.Write("Enter team name: ");
                    string teamName = Console.ReadLine();
                    Team team = teams.Find(t => t.Name == teamName);
                    if (team != null)
                    {
                        team.ListPlayers();
                    }
                    else
                    {
                        Console.WriteLine("Team not found");
                    }
                }
                else if (command == "save")
                {
                    Console.Write("Enter team name: ");
                    string teamName = Console.ReadLine();
                    Team team = teams.Find(t => t.Name == teamName);
                    if (team != null)
                    {
                        team.SavePlayersToCsv();
                    }
                    else
                    {
                        Console.WriteLine("Team not found");
                    }
                }
                else if (command == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }
    }
}