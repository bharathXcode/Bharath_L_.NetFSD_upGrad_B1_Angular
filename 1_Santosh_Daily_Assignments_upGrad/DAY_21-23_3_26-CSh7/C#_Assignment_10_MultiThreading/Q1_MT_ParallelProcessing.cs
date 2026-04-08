using System;
using System.Collections.Generic;
using System.Threading;

// Q1 - Parallel Number Processing using Threads
class Q1_MT_ParallelProcessing
{
    // Shared list to store partial sums from each thread
    static int[] partialSums = new int[5];

    static void Main(string[] args)
    {
        // 1. Create numbers from 1 to 50
        List<int> numbers = new List<int>();
        for (int i = 1; i <= 50; i++)
            numbers.Add(i);

        // 2. Split into 5 parts (each part = 10 numbers)
        int partSize = 10;

        // Array to hold 5 threads
        Thread[] threads = new Thread[5];

        // 3. Create 5 threads
        for (int i = 0; i < 5; i++)
        {
            int threadIndex = i; // Important for closure

            threads[i] = new Thread(() =>
            {
                int start = threadIndex * partSize;
                int end = start + partSize;

                int sum = 0;

                Console.WriteLine($"\nThread {threadIndex + 1} processing:");

                // Each thread processes its part
                for (int j = start; j < end; j++)
                {
                    Console.Write(numbers[j] + " ");
                    sum += numbers[j];
                }

                // Store partial sum
                partialSums[threadIndex] = sum;

                Console.WriteLine($"\nThread {threadIndex + 1} Sum: {sum}");
            });

            // Start thread
            threads[i].Start();
        }

        // Wait for all threads to complete
        for (int i = 0; i < 5; i++)
        {
            threads[i].Join();
        }

        // Final sum calculation
        int finalSum = 0;
        foreach (var s in partialSums)
            finalSum += s;

        Console.WriteLine($"\nFinal Sum: {finalSum}");
    }
}