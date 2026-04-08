using System;

class Q2_CommandLineGreeting
{
    public static void Run()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Hi! " + name);
        Console.WriteLine("Welcome to the world of C#");
    }
}