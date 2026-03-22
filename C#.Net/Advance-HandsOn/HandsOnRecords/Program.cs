using System.Linq.Expressions;

namespace HandsOnRecords
{
    //creating and using record.
   
    public record Student(int Id, string Name, int Marks);
    public record Person(string FirstName, string LastName);
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(1, "Ravi", 90);
            //s1.Name = "Rohan";//records are immutable by default
            Console.WriteLine(s1);
            var person1 = new Person("John", "Die");
            Console.WriteLine($"FirstName:{person1.FirstName} LastName:{person1.LastName}");
            var person2 = new Person("John", "Die");
            Console.WriteLine(person1==person2); //True: Value Equality
            var person3 = person1 with { FirstName = "Virat" }; //Non - Destructive Mutation(with Expression)
            Console.WriteLine(person3); //// Output: Person { FirstName = Virat, LastName = Doe }
        }
    }
}
