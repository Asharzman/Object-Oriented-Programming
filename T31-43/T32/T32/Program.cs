using System;

namespace Delegates
{
    delegate string StringTransformer(string str);

    class Delegater
    {
        static string ToUpperCase(string str)           // Transformation method
        {
            return str.ToUpper();
        }

        static string ToLowerCase(string str)           // Transformation method
        {
            return str.ToLower();
        }

        static string ToTitleCase(string str)           // Transformation method
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        static string ToPalindrome(string str)          // Transformation method
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        public void Operator()
        {
            Console.WriteLine("Enter the string to process:");
            string str = Console.ReadLine();
            StringTransformer transformer = null;
            Console.WriteLine("Choose the treatment you want, you can give several treatments at once " +
                "as one string, e.g. '123'");
            Console.WriteLine("1: to capital letters");
            Console.WriteLine("2: lowercase");
            Console.WriteLine("3: as a title");
            Console.WriteLine("4: as a palindrome");
            Console.WriteLine("0: termination");

            while (true)
            {
                string selection = Console.ReadLine();

                if (selection.Contains("1"))
                {
                    transformer += ToUpperCase;
                }

                if (selection.Contains("2"))
                {
                    transformer += ToLowerCase;
                }

                if (selection.Contains("3"))
                {
                    transformer += ToTitleCase;
                }

                if (selection.Contains("4"))
                {
                    transformer += ToPalindrome;
                }

                if (selection == "0")
                {
                    break;
                }
                var transformedStr = transformer(str);
                Console.WriteLine($"{str} changed to {transformedStr}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Delegater delcat = new Delegater();
            Console.WriteLine("______     _                  _            \r\n|  _  \\   | |                | |           \r\n| | | |___| | ___  __ _  __ _| |_ ___  ___ \r\n| | | / _ \\ |/ _ \\/ _` |/ _` | __/ _ \\/ __|\r\n| |/ /  __/ |  __/ (_| | (_| | ||  __/\\__ \\\r\n|___/ \\___|_|\\___|\\__, |\\__,_|\\__\\___||___/\r\n                   __/ |                   \r\n                  |___/                    ");
            Console.WriteLine("-----------------------------------------------------\n");
            delcat.Operator();
        }
    }
   
}