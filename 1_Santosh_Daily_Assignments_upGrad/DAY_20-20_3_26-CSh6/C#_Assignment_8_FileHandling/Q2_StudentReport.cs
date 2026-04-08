using System;
using System.IO;

class Q2_StudentReport
{
    static string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
    static string dataFolder = Path.Combine(basePath, "Data");

    static void Main()
    {
        Directory.CreateDirectory(dataFolder);

        Console.WriteLine("1.Create  2.View");
        int ch = int.Parse(Console.ReadLine());

        if (ch == 1) Create();
        else View();
    }

    static void Create()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Roll: ");
        string roll = Console.ReadLine();

        int m1 = int.Parse(Console.ReadLine());
        int m2 = int.Parse(Console.ReadLine());
        int m3 = int.Parse(Console.ReadLine());

        int total = m1 + m2 + m3;
        double avg = total / 3.0;

        string grade = avg >= 75 ? "A" :
                       avg >= 50 ? "B" :
                       avg >= 35 ? "C" : "Fail";

        string content =
$@"Name: {name}
Roll: {roll}
Marks: {m1},{m2},{m3}
Total: {total}
Average: {avg}
Grade: {grade}";

        string path = Path.Combine(dataFolder, roll + ".txt");
        File.WriteAllText(path, content);
    }

    static void View()
    {
        Console.Write("Roll: ");
        string roll = Console.ReadLine();

        string path = Path.Combine(dataFolder, roll + ".txt");

        if (File.Exists(path))
            Console.WriteLine(File.ReadAllText(path));
        else
            Console.WriteLine("Not found");
    }
}
