using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Net.Cache;
using System.Runtime.InteropServices;

public class Names
{
    public struct People
    {
        public People()
        {
            Name = "Undefined";
            Birthyear = 0;
            Year = 0;
        }
        public People(string name, int birthyear, int date)
        {
            Name = name;
            Birthyear = birthyear;
            Year = date - birthyear;
        }

        public string Name { get; }
        public int Birthyear { get; }
        public int Year { get; }

        public override string ToString() 
        { 
           return $"{Name}, he is {Year} years old."; 
        }
    }
    static void Main()
    {
        string[] personslist = Array.Empty<string>();
        while (true)
        {
            DateTime now = DateTime.Today;
            string year = (now.ToString("yyyy"));
            int truedate = Int32.Parse(year);
            Console.WriteLine("Please enter name following with birthyear. (name, year): ");
            var theinput = Console.ReadLine();
            if (theinput == "")
            {
                break;
            }
            else
            {
                string first = theinput.Split(',').FirstOrDefault();
                string middle = theinput.Substring(theinput.LastIndexOf(',') + 1);
                middle ??= "0";
                string last = string.Concat(middle.Where(c => !Char.IsWhiteSpace(c)));
                int trueyear = Int32.Parse(last);
                var newperson = new People(first, trueyear, truedate);
                string newentry = newperson.ToString();
                personslist = personslist.Append(newentry).ToArray();
            }
        }
        var totalElements = personslist.Count();
        Console.WriteLine("...");
        Console.WriteLine(totalElements + " names were given.");
        foreach (string i in personslist)
        {
            Console.Write($"{i}\n"); // output: NaN (Undefined)
        }
    }
}
