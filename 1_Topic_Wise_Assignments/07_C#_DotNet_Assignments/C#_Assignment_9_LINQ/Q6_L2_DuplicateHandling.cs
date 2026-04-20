using System;
using System.Collections.Generic;
using System.Linq;

// Q6 - Handling duplicates
class Q6_L2_DuplicateHandling
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6 };

        // Remove duplicates
        var unique = numbers.Distinct();

        // Find duplicate values
        var duplicates = numbers.GroupBy(n => n)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key);

        // Count occurrences of each number
        var count = numbers.GroupBy(n => n)
                           .Select(g => new { Num = g.Key, Count = g.Count() });
    }
}
