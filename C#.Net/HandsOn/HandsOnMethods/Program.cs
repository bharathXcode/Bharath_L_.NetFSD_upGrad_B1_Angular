namespace HandsOnMethods
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee(int Id,string Name)
        {
            this.Id = Id;
            this.Name= Name;
        }
        public void Details()
        {
            Console.WriteLine($"Id:{Id} Name:{Name}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee e1 = new Employee(3323,"Vikas");
            e1.Details();
        }
    }
}
