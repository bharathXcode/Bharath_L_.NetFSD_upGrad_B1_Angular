using System.IO;
namespace HandsOnFileOperations
{
    internal class Program
    {
        static void Read(string ?path)
        {
            try
            {
                StreamReader streamReader = new StreamReader(path);
                string ?content = streamReader.ReadToEnd(); //Read the file
                Console.WriteLine(content);
            }
            catch (IOException)
            {

                throw;
            }
        }
        static void Write(string path)
        {
            try
            {
               string content = "All glitters are not Gold!!!";
               // string content = "Good Morning Users";
                //using block automaticly close/dispose the objects
                using (StreamWriter streamWriter = new StreamWriter(path,true))
                {
                    streamWriter.WriteLine(content); //content added to file
                   // streamWriter.Dispose(); //to dispose the object

                }
            }
            catch (IOException)
            {

                throw;
            }
        }
        static void WriteObjets(string path)
        {
            try
            {
                List<Student> students = new List<Student>()
                {
                    new Student(){Id=1,Name="Ram",Age=10},
                     new Student(){Id=2,Name="Tina",Age=11},
                      new Student(){Id=3,Name="Raj",Age=12},
                };
                foreach (var item in students)
                {
                    using (StreamWriter streamWriter = new StreamWriter(path))
                    {
                        streamWriter.WriteLine(item); //content added to file

                    }
                }
                
            }
            catch (IOException)
            {

                throw;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                //Read(@"D:\CTS(2-16-2026)\dotnet-angular\C#.Net\HandsOn\HandsOnArrays\Demo1.cs");
                Console.WriteLine("Enter File Path");
                string ?path = Console.ReadLine();
                Read(path);
               // Write(path);
                //WriteObjets(path);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
