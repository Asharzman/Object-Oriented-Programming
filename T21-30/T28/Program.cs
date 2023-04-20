using System;
using System.Collections.Generic;

namespace Fridge
{
    class Refrigerator
    {
        private List<string> contents;

        public Refrigerator()
        {
            contents = new List<string>();
        }

        public void AddItem(string item)
        {
            contents.Add(item);
        }

        public void RemoveItem(string item)
        {
            contents.Remove(item);
        }

        public void ListContents()
        {
            Console.WriteLine("The refrigerator contains:");
            foreach (string item in contents)
            {
                Console.WriteLine("- " + item);
            }
        }

        public void AddFromInput()
        {
            Console.WriteLine("Enter item to add to the refrigerator:");
            string item = Console.ReadLine();
            AddItem(item);
            Console.WriteLine("Added " + item + " to the refrigerator.");
        }

        public void RemoveFromInput()
        {
            Console.WriteLine("Enter item to remove from the refrigerator:");
            string item = Console.ReadLine();
            RemoveItem(item);
            Console.WriteLine("Removed " + item + " from the refrigerator.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Refrigerator fridge = new Refrigerator();

            fridge.AddItem("Milk");
            fridge.AddItem("Eggs");
            fridge.AddItem("Cheese");
            fridge.AddItem("Leftover Pizza");
            Console.WriteLine("______    _     _            \r\n|  ___|  (_)   | |           \r\n| |_ _ __ _  __| | __ _  ___ \r\n|  _| '__| |/ _` |/ _` |/ _ \\\r\n| | | |  | | (_| | (_| |  __/\r\n\\_| |_|  |_|\\__,_|\\__, |\\___|\r\n                   __/ |     \r\n                  |___/      ");
            while (true)
            {
                fridge.ListContents();
                Console.WriteLine("Possible options are: add, remove or quit.");
                string input = Console.ReadLine();
                if (input == "add")
                {
                    fridge.AddFromInput();
                }
                else if (input == "remove")
                {
                    fridge.RemoveFromInput();
                }
                else if ( input == "quit" || input == "" || input == "not hungry" )
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Invalid command.");
                }

            }
        }
    }
}