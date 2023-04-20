using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Palindromes
{
    public static class Eval
    {
        public static bool result;

        public static string ReverseString(string myStr)
        {
            char[] myArr = myStr.ToCharArray();
            Array.Reverse(myArr);
            return new string(myArr);
        }
        public static void checker(string word)
        {
            string word2 = word.ToLower();
            string trimmed = string.Concat(word2.Where(c => !Char.IsWhiteSpace(c)));
            string wordreversed = ReverseString(trimmed);
            result = trimmed.Equals(wordreversed);
        }

    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a palindrome: ");
        string dvorak = Console.ReadLine();
        Eval.checker(dvorak);
        if (Eval.result == true)
        {
            Console.WriteLine("It is a palindrome!");
        }
        else
        {
            Console.WriteLine("Not a palindrome.");
        }
        Console.ReadKey();
    }
}
