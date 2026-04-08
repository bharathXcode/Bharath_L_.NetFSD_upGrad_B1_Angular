using System;
using System.IO;

class Q3_MiniNotepad
{
    static string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
    static string dataFolder = Path.Combine(basePath, "Data");

    static void Main()
    {
        Directory.CreateDirectory(dataFolder);

        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine() + ".txt";
        string file = Path.Combine(dataFolder, fileName);

        while (true)
        {
            Console.WriteLine("\n1.Create 2.Write 3.Read 4.Append 5.Delete 6.Exit");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    File.Create(file).Close();
                    break;

                case 2:
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        string line;
                        while ((line = Console.ReadLine()) != "end")
                        {
                            sw.WriteLine(line);
                        }
                    }
                    break;

                case 3:
                    if (File.Exists(file))
                        Console.WriteLine(File.ReadAllText(file));
                    break;

                case 4:
                    using (StreamWriter sw = new StreamWriter(file, true))
                    {
                        string line;
                        while ((line = Console.ReadLine()) != "end")
                        {
                            sw.WriteLine(line);
                        }
                    }
                    break;

                case 5:
                    if (File.Exists(file))
                        File.Delete(file);
                    break;

                case 6:
                    return;
            }
        }
    }
}
