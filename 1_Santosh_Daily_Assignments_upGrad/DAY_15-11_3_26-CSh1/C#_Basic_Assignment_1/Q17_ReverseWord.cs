using System;

class Q17_ReverseWord
{
    public static void Run()
    {
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        char[] arr = word.ToCharArray();
        Array.Reverse(arr);

        Console.WriteLine("Reverse = " + new string(arr));
    }
}
