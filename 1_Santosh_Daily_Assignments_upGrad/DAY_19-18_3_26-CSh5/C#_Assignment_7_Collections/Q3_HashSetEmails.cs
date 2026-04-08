using System;
using System.Collections.Generic;

class Q3_HashSetEmails
{
    public static void Main()
    {
        HashSet<string> emails = new HashSet<string>
        {
            "a@gmail.com",
            "b@gmail.com",
            "c@gmail.com",
            "d@gmail.com",
            "e@gmail.com",
            "f@gmail.com",
            "g@gmail.com",
            "h@gmail.com",

            // duplicates intentionally
            "a@gmail.com",
            "c@gmail.com"
        };

        Console.WriteLine("Unique Emails:");
        foreach (var e in emails)
            Console.WriteLine(e);

        Console.WriteLine("\nCheck email:");
        Console.WriteLine(emails.Contains("a@gmail.com"));

        Console.WriteLine("\nAfter removing b@gmail.com:");
        emails.Remove("b@gmail.com");

        foreach (var e in emails)
            Console.WriteLine(e);
    }
}