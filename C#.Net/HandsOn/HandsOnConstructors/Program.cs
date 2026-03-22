namespace HandsOnConstructors
{
    class Employee
    {
        public int Id;
        public string Name;
        //default constructor
        public Employee()
        {
            Id = 1;
            Name = "Raj";
        }
        //Parameterized constructor
        public Employee(int id, string name)
        {
            Id = id;
            Name= name;
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
            Employee e1=new Employee();
            e1.Details();
            Employee e2=new Employee(23,"Kavya");
            e2.Details();
            Employee e3 = new Employee(43, "Pavan");
            e3.Details();
        }
    }
}
