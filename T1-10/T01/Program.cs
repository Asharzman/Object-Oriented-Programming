using System;

class Student_Grading
{
    static public void Main()
    {
        Console.WriteLine("Give points: ");
        int score = Convert.ToInt32(Console.ReadLine());

        if (score >= 0 && score <= 19)
        {
            int grade = 0;
            Console.WriteLine("Your grade is: " + $"{grade}");
            Console.ReadLine();
        }
        else if (score >= 20 && score <= 29)
        {
            int grade = 1;
            Console.WriteLine("Your grade is: " + $"{grade}");
            Console.ReadLine();
        }
        else if (score >= 30 && score <= 39)
        {
            int grade = 2;
            Console.WriteLine("Your grade is: " + $"{grade}");
            Console.ReadLine();
        }
        else if (score >= 40 && score <= 49)
        {
            int grade = 3;
            Console.WriteLine("Your grade is: " + $"{grade}");
            Console.ReadLine();
        }
        else if (score >= 50 && score <= 59)
        {
            int grade = 4;
            Console.WriteLine("Your grade is: " + $"{grade}");
            Console.ReadLine();
        }
        else if (score >= 60 && score <= 70)
        {
            int grade = 5;
            Console.WriteLine("Your grade is: " + $"{grade}");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Something unexpected happened! Press Enter to exit.");
            Console.ReadLine();
        }
    }
}