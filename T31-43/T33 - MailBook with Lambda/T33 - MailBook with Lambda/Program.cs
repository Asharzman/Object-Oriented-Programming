using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyMailBook
{
    class Friend
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    class MailBook
    {
        private readonly List<Friend> _friends;

        public IReadOnlyList<Friend> Friends => _friends;

        public MailBook()
        {
            _friends = new List<Friend>();

            // Read the friend.csv file and save the data to Friend objects
            try
            {
                string[] lines = File.ReadAllLines("friend.csv");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 2)
                    {
                        Friend friend = new Friend
                        {
                            Name = parts[0].Trim(),
                            Email = parts[1].Trim()
                        };

                        _friends.Add(friend);
                    }
                }

                Console.WriteLine($"{_friends.Count} names in the address book:");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        public void ShowFriends()
        {
            foreach (Friend friend in _friends)
            {
                Console.WriteLine($"{friend.Name} {friend.Email}");
            }
        }

        public void SearchFriends(string search)
        {
            List<Friend> results = _friends.Where(friend => friend.Name.Contains(search)).ToList();

            if (results.Count > 0)
            {
                foreach (Friend friend in results)
                {
                    Console.WriteLine($"{friend.Name} {friend.Email}");
                }
            }
            else
            {
                Console.WriteLine("No matches found.");
            }
        }

        public void AddFriend(string name, string email)
        {
            try
            {
                Friend friend = new Friend
                {
                    Name = name,
                    Email = email
                };

                _friends.Add(friend);

                using (StreamWriter writer = new StreamWriter("friend.csv", true))
                {
                    writer.WriteLine($"{name}, {email}");
                }

                Console.WriteLine("Friend added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding friend: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___  ___      _ _ _                 _    \r\n|  \\/  |     (_) | |               | |   \r\n| .  . | __ _ _| | |__   ___   ___ | | __\r\n| |\\/| |/ _` | | | '_ \\ / _ \\ / _ \\| |/ /\r\n| |  | | (_| | | | |_) | (_) | (_) |   < \r\n\\_|  |_/\\__,_|_|_|_.__/ \\___/ \\___/|_|\\_\\\r\n                                         \r\n                                         ");
            MailBook mailBook = new MailBook();
            Console.WriteLine("Current Friends:\n");
            mailBook.ShowFriends();
            Console.WriteLine("-----------------------\n");
            Console.WriteLine("Controls. 1 = Add friend | 2 = Search Friends | 0 = Exit");
            while (true) 
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("Enter the name of the new friend:");
                    string name = Console.ReadLine();
                    if (name == "")
                    {
                        Console.WriteLine("Name cannot be empty!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("Enter the email of the new friend:");
                        string email = Console.ReadLine();
                        mailBook.AddFriend(name, email);
                        Console.WriteLine("Program completed successfully. Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (input == "2")
                {
                    Console.Write("Enter the name or part of the name of the person you are looking for:");
                    string search = Console.ReadLine();
                    Console.WriteLine("\nSearch results:\n");
                    Console.WriteLine("\n--------------------\n");
                    mailBook.SearchFriends(search);
                    Console.WriteLine("\n--------------------\n");
                }
                else if (input == "3")
                {
                    Console.WriteLine("Exiting program, see you later!");
                    System.Threading.Thread.Sleep(5000);
                    { break; }
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }
            }
            
        }
    }
}