using System;
using System.Linq;

class Q15_MarksAnalysis
{
    public static void Run()
    {
        int[] marks = new int[10];

        Console.WriteLine("Enter 10 marks:");

        for (int i = 0; i < 10; i++)
            marks[i] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Total = " + marks.Sum());
        Console.WriteLine("Average = " + marks.Average());
        Console.WriteLine("Minimum = " + marks.Min());
        Console.WriteLine("Maximum = " + marks.Max());

        Console.WriteLine("Ascending Order:");
        foreach (var m in marks.OrderBy(x => x))
            Console.Write(m + " ");

        Console.WriteLine("\nDescending Order:");
        foreach (var m in marks.OrderByDescending(x => x))
            Console.Write(m + " ");
    }
}
