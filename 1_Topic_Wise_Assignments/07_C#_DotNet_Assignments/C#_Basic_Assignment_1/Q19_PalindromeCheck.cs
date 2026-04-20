using System;

class Q19_PalindromeCheck
{
    public static void Run()
    {
        Console.Write("Enter word: ");
        string word = Console.ReadLine();

        char[] arr = word.ToCharArray();
        Array.Reverse(arr);

        string rev = new string(arr);

        if (word == rev)
            Console.WriteLine("Palindrome");
        else
            Console.WriteLine("Not Palindrome");
    }
}
