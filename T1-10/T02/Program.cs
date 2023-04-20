using System;

class Hill_Jumping
{
    static public void Main()
    {
        int[] scores = new int[5];
        for (int i = 0; i < 5; i++) 
        {
            Console.WriteLine("Give points: ");
            scores[i] = Convert.ToInt32(Console.ReadLine());
        }
        int sum = scores.Sum();
        Console.WriteLine("Total points are " + sum);
    }
}
