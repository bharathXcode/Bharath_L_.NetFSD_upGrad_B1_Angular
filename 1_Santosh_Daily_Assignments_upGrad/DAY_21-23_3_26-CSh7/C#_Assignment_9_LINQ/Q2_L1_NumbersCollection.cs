using System;
using System.Collections.Generic;
using System.Linq;

// Q2 - Operations on number collection
class Q2_L1_NumbersCollection
{
    static void Main(string[] args)
    {
        // Input list of numbers
        var numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

        // 1. Get even numbers
        var even = numbers.Where(n => n % 2 == 0);

        // 2. Get numbers greater than 15
        var greater = numbers.Where(n => n > 15);

        // 3. Get square of each number
        var squares = numbers.Select(n => n * n);

        // 4. Count numbers divisible by 5
        int count = numbers.Count(n => n % 5 == 0);

        // Display results
        Console.WriteLine("Even Numbers:");
        even.ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\nGreater than 15:");
        greater.ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\nSquares:");
        squares.ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\nCount divisible by 5:");
        Console.WriteLine(count);
    }
}