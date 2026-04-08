using System;

class Q18_CompareTwoWords
{
    public static void Run()
    {
        Console.Write("Enter first word: ");
        string w1 = Console.ReadLine();

        Console.Write("Enter second word: ");
        string w2 = Console.ReadLine();

        if (w1 == w2)
            Console.WriteLine("Words are same");
        else
            Console.WriteLine("Words are different");
    }
}
