using System;
using System.Collections.Generic;
using System.Linq;

// Q3 - String operations using LINQ
class Q3_L1_StringOperations
{
    static void Main(string[] args)
    {
        // Input list of names
        var names = new List<string> { "Ravi", "Kiran", "Amit", "Raj", "Anil" };

        // 1. Names starting with 'A'
        var startsWithA = names.Where(n => n.StartsWith("A"));

        // 2. Sort names alphabetically
        var sorted = names.OrderBy(n => n);

        // 3. Convert all names to uppercase
        var upper = names.Select(n => n.ToUpper());

        // 4. Names with length greater than 4
        var lengthFilter = names.Where(n => n.Length > 4);

        // Display results
        Console.WriteLine("Starts with A:");
        startsWithA.ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\nSorted:");
        sorted.ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\nUppercase:");
        upper.ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\nLength > 4:");
        lengthFilter.ToList().ForEach(Console.WriteLine);
    }
}
