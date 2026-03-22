using HandsOnGenericCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_Queue
{
    /*
     What it is: A FIFO (First In, First Out) collection.

When to use: When you want to process items in the order they arrive (like a waiting line).
     */

    class Program
    {
        static void Main()
        {
            Queue<string> tasks = new Queue<string>();
            //Add items to the Queue
            tasks.Enqueue("Task1");
            tasks.Enqueue("Task2");
            tasks.Enqueue("Task3");

            Console.WriteLine(tasks.Dequeue()); // Task1 (first in) //remove items
            Console.WriteLine(tasks.Peek());   // Retrun 1st item

            Queue<Student> studentQueue = new Queue<Student>();

            studentQueue.Enqueue(new Student { Id = 1, Name = "Alice", Marks = 85 });
            studentQueue.Enqueue(new Student { Id = 2, Name = "Bob", Marks = 90 });

            Console.WriteLine($"Dequeued: {studentQueue.Dequeue()}"); // Alice
            Console.WriteLine($"Peek: {studentQueue.Peek()}");        // Bob
        }
    }

}
