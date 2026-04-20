using System;

class Q8_VowelOrConsonant
{
    public static void Run()
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        if (str.Length >= 3)
        {
            char ch = char.ToLower(str[2]);

            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                Console.WriteLine("Third character is a vowel");
            else
                Console.WriteLine("Third character is a consonant");
        }
        else
        {
            Console.WriteLine("String must contain at least 3 characters");
        }
    }
}
