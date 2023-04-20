using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Randomer
{
    class Person    // Person class here!
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    class Randomizer
    {
        private static string GetRandomName(int length)     // Method for generating random name
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void ListMethod()     // List method for name collection
        {
            List<Person> list = new List<Person>();
            Stopwatch stopWatch = new Stopwatch();
            Random random = new Random();

            stopWatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                string firstName = GetRandomName(4);
                string lastName = GetRandomName(10);

                Person person = new Person(firstName, lastName);
                list.Add(person);
            }

            stopWatch.Stop();

            Console.WriteLine("List Collection:");
            Console.WriteLine("- Adding time : {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("- Persons count : {0}", list.Count);
            Console.WriteLine($"- Random person : {list[random.Next(list.Count)].FirstName} {list[random.Next(list.Count)].LastName}\n");

            stopWatch.Reset();
            stopWatch.Start();

            List<Person> foundPersons = new List<Person>();

            for (int i = 0; i < 1000; i++)
            {
                string firstName = GetRandomName(4);

                foreach (Person person in list)
                {
                    if (person.FirstName == firstName)
                    {
                        foundPersons.Add(person);
                    }
                }
            }

            stopWatch.Stop();

            Console.WriteLine("Finding persons in collection (by first name):");

            foreach (Person person in foundPersons)
            {
                Console.WriteLine($"- Found person with {person.FirstName} firstname : {person.FirstName} {person.LastName}");
            }
            Console.WriteLine("- Persons tried to find : {0}", 1000);
            Console.WriteLine("- Total finding time: {0} ms", stopWatch.ElapsedMilliseconds);
        }

        public void DictionaryMethod()      // Dictionary method for collecting names
        {
            static string GetRandomPersonName(Dictionary<string, Person> peopleDict, Random rand)
            {
                int index = rand.Next(peopleDict.Count);
                string[] keys = new string[peopleDict.Count];
                peopleDict.Keys.CopyTo(keys, 0);
                return peopleDict[keys[index]].FirstName + " " + peopleDict[keys[index]].LastName;
            }

            Dictionary<string, Person> personDictionary = new Dictionary<string, Person>();
            Stopwatch dictionaryStopwatch = new Stopwatch();
            Random random = new Random();

            for (int i = 0; i < 10000; i++)
            {
                string firstName = GetRandomName(4);
                string lastName = GetRandomName(10);
                Person p = new Person(firstName, lastName);

                if (!personDictionary.ContainsKey(firstName))
                {
                    personDictionary.Add(firstName, p);
                }
            }

            dictionaryStopwatch.Start();    // Starts the watch

            int count = 1000;
            for (int i = 0; i < count; i++)
            {
                string firstName = GetRandomName(4);
                if (personDictionary.ContainsKey(firstName))
                {
                    Console.WriteLine($"- Found person with {firstName} firstname : {firstName} {personDictionary[firstName].LastName}");
                }
            }

            dictionaryStopwatch.Stop();     // Stops the watch

            Console.WriteLine($"\nDictionary Collection:");
            Console.WriteLine($"- Adding time : {dictionaryStopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"- Persons count : {personDictionary.Count}");
            Console.WriteLine("- Random person : " + GetRandomPersonName(personDictionary, random));
            Console.WriteLine($"- Persons tried to find : {count}");
            Console.WriteLine($"- Total finding time: {dictionaryStopwatch.ElapsedMilliseconds} ms");
        }
    }
        
    internal class Program
    {
        static void Main(string[] args)
        {
            Randomizer randy = new Randomizer();
            Console.WriteLine("______                _                   _   _                           \r\n| ___ \\              | |                 | \\ | |                          \r\n| |_/ /__ _ _ __   __| | ___  _ __ ___   |  \\| | __ _ _ __ ___   ___  ___ \r\n|    // _` | '_ \\ / _` |/ _ \\| '_ ` _ \\  | . ` |/ _` | '_ ` _ \\ / _ \\/ __|\r\n| |\\ \\ (_| | | | | (_| | (_) | | | | | | | |\\  | (_| | | | | | |  __/\\__ \\\r\n\\_| \\_\\__,_|_| |_|\\__,_|\\___/|_| |_| |_| \\_| \\_/\\__,_|_| |_| |_|\\___||___/\r\n                                                                          \r\n                                                                          \n");
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("Press any key to see the list method.");
            Console.ReadLine();
            randy.ListMethod();
            Console.WriteLine("\nPress any key to output dictionary.");
            Console.ReadLine();
            randy.DictionaryMethod();
            Console.WriteLine("\nPress any key to exit program.");
            Console.ReadLine();
        }
    }

}