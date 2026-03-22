namespace HandsOnTypeConversions
{
   
    internal class Program
    {
        static void ImplicitConversion()
        {
            byte b = 100;
            int i = b; //implicit
            char ch = 'a';
            i = ch;//implicit
            float f = 34.456f;
            double d = f; //implicit
        }
        static void Casting()
        {
            //casting works in between value types
            int k = 100;
            byte b = (byte)k; //convert int ot byte
            short s = (short)k; //convert int to short
            long l = 2345;
            k = (int)l;//convert long to int
            double d = 34.45;
            l= (long)d; //lose of precession //convert double to long
            Console.WriteLine(l);
        }
        static void ConvertConversion()
        {
            string s = "123";
            int k=Convert.ToInt32(s);//convert string to int
            double d=Convert.ToDouble(s); //convert string to dobule
            long l=Convert.ToInt64(s); //convert string to long
            float f = Convert.ToSingle(s); //convert string to floast
            int n = 3343;
            string s1 = n.ToString();//convret int to string
            double d1 = 45.34;
            int m=Convert.ToInt32(d1); //convert double to int
            Console.WriteLine(m);
        }
        static void ParseConversion()
        {
            //Parsing is use to convert string to any value type
            string s="123"; 
            int k=int.Parse(s); //convert string to int
            short s1 = short.Parse(s);
            byte b = byte.Parse(s);
            long l = long.Parse(s);
            //k = int.Parse("abc"); //runtime exception
            double d = double.Parse(s);
            Console.WriteLine(d);

        }
        static void Boxing()
        {
            object k = 231;
            object m = "abc";
            //boxing is the concept of convert value type to object and it is implicit
            int i = 100;
            object o = i;
            double d = 23.34;
            object o1 = d;
            short s = 23;
            object o2 = s;
        }
        static void UnBoxing()
        {
            //unboxing is the concept to convet object to value datatypes and unboxing require casting
            object o = 123;
            int k=(int)o; //using casting
            k = Convert.ToInt32(o); //convert object to int
            object o1 = 23.345;
            double d = (double)o1;
            d = Convert.ToDouble(o1); //convert object to double
        }
        static void Main(string[] args)
        {
            ImplicitConversion();
            Casting();
            ConvertConversion();
            ParseConversion();
            Boxing();
            UnBoxing();
        }
    }
}
