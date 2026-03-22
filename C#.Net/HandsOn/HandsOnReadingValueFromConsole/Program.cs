namespace HandsOnReadingValueFromConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine(); //readLine() reads any value from console window and returns in string form
            Console.WriteLine("Hello " + name);
            Console.WriteLine($"Hello {name}");
            Console.WriteLine("Enter Age:");
            //int age=int.Parse( Console.ReadLine());
            int age = Convert.ToInt32(Console.ReadLine());//retrun 0 when string value is null
            Console.WriteLine($"Name:{name} Age:{age}");
        }
    }
}
