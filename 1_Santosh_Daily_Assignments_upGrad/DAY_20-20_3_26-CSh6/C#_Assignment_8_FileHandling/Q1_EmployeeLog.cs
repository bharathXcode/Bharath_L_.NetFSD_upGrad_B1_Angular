using System;
using System.IO;
using System.Collections.Generic;

class Q1_EmployeeLog
{
    static string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
    static string dataFolder = Path.Combine(basePath, "Data");
    static string filePath = Path.Combine(dataFolder, "employee_log.txt");

    static void Main()
    {
        Directory.CreateDirectory(dataFolder);

        while (true)
        {
            Console.WriteLine("\n1.Add Login  2.Update Logout  3.Display  4.Exit");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1: AddLogin(); break;
                case 2: UpdateLogout(); break;
                case 3: Display(); break;
                case 4: return;
            }
        }
    }

    static void AddLogin()
    {
        Console.Write("ID: ");
        string id = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine($"{id}|{name}|{DateTime.Now}|");
        }
    }

    static void UpdateLogout()
    {
        if (!File.Exists(filePath)) return;

        Console.Write("Enter ID: ");
        string id = Console.ReadLine();

        var lines = new List<string>(File.ReadAllLines(filePath));

        for (int i = 0; i < lines.Count; i++)
        {
            var p = lines[i].Split('|');

            if (p[0] == id && p[3] == "")
            {
                p[3] = DateTime.Now.ToString();
                lines[i] = string.Join("|", p);
                break;
            }
        }

        File.WriteAllLines(filePath, lines);
    }

    static void Display()
    {
        if (File.Exists(filePath))
            Console.WriteLine(File.ReadAllText(filePath));
        else
            Console.WriteLine("No Data");
    }
}
