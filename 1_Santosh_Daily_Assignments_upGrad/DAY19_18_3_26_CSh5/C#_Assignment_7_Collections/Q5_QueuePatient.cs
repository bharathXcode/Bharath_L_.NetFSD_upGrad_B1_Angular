using System;
using System.Collections.Generic;

class Patient
{
    public int Id;
    public string Name;
    public string Disease;
}

class Q5_QueuePatient
{
    public static void Main()
    {
        Queue<Patient> queue = new Queue<Patient>();

        queue.Enqueue(new Patient { Id = 1, Name = "A", Disease = "Fever" });
        queue.Enqueue(new Patient { Id = 2, Name = "B", Disease = "Cold" });
        queue.Enqueue(new Patient { Id = 3, Name = "C", Disease = "Cough" });
        queue.Enqueue(new Patient { Id = 4, Name = "D", Disease = "Flu" });
        queue.Enqueue(new Patient { Id = 5, Name = "E", Disease = "Headache" });

        queue.Dequeue();
        queue.Dequeue();

        Console.WriteLine("Next Patient: " + queue.Peek().Name);

        Console.WriteLine("Remaining:");
        foreach (var p in queue)
            Console.WriteLine(p.Name);
    }
}
