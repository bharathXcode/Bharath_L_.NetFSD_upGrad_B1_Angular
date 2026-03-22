namespace HandsOnClassesAndObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //student object creation
            Student s1 = new Student();
            s1.id = 100;
            s1.name = "Rohan";
            s1.Display();
            Student s2 = new Student 
            { id = 200, name = "Viart" };
            s2.Display();
            Student s3 = new Student();
            s3.Display();
            //create Student array
            Student[] students = new Student[5];
            students[0] = new Student()
            { id = 4, name = "Varun" };
            students[1] = s1;
            students[2] = s2;
            students[3] = s3;
            students[4] = new Student();
            students[4].id = 5;
            students[4].name = "Vikas";
            Console.WriteLine();
            foreach (Student s in students)
            {
                s.Display();
            }
        }
    }
}
