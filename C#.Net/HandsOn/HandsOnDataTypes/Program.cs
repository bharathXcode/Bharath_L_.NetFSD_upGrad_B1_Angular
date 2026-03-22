namespace HandsOnDataTypes
{
    internal class Program
    {
        static void ValueTypes()
        {
            //numeric types
            byte b = 90;
            short s = 890;
            int i = 9098;
            long l = 89098;
            //decimal types
            double d = 23.4;
            float f = 43.213F;
            decimal dc = 23.3445667M;
            //char types
            char ch = 'a';
            //boolean types
            bool result= false;
            DateTime dt = new DateTime(2023, 12, 23);
            Console.WriteLine(dt);
            Console.WriteLine("i= " + i);
        }
        static void ReferenceTypes()
        {
            string s = "Hello World";
            Console.WriteLine(s);
            //object types allow any type of value to store
            object ob = 123;
            object ob1 = "Ram";
            Random r = new Random(); //class is also reference type
            string[] flowers = new string[] { "Rose", "Lilly" };
        }
        static void OtherTypes()
        {
            var k = 100;
            var a = "Rohan";
            var c = 'a';
            dynamic m = 12.3;
            Console.WriteLine(m);
            m = "Ram";
            Console.WriteLine(m);
            m = true;
            Console.WriteLine(m);
        }
        static void Main(string[] args)
        {
            ValueTypes();
            ReferenceTypes();
            OtherTypes();
        }
    }
}
