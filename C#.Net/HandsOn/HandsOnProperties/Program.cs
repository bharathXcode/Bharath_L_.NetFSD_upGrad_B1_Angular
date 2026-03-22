namespace HandsOnProperties
{
    class Student
    {
        private int _id;
        private string _name;
        private int _age;
        //Properties
        public int Id
        {
            get { return _id; } //return private variable value
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { 
            if(value>0)
                {
                    _age = value;
                }
            else
                {
                    Console.WriteLine("Invalid Age");
                }
            }
        }
        public void Details()
        {
            Console.WriteLine($"Id:{_id} Name:{_name} Age:{_age}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Student student = new Student();
            student.Id = 3498; //Id set accessor invoke
            student.Name = "Rohan"; //Name set acccessor is invoke
            student.Age = -10;
            Console.WriteLine("Welcome " + student.Name); //Name get accessor is invoke
            student.Details();
            
        }
    }
}
