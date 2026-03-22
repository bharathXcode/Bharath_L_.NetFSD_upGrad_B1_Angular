using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInheritance
{
    public class A
    {
        public int a;
        private int b;
        protected int c;
        internal int d;
        protected internal int e;
        int g; //private
    }
     class B:A
    {
        public void M()
        {
            Console.WriteLine("a= " + a);//public members can access
           // Console.WriteLine("b= " + b); //private members are not accessable
            Console.WriteLine("c= " + c); //protected members are accessable
            Console.WriteLine("d= " + d); //internal members are accessable
            Console.WriteLine("e= " + e); //protected internal members are accessable

        }
    }
    class Test_B
    {
        static void Main()
        {
            B obj = new B();
            //using object refernce only public,internal and protected internal members of any class can access
            //using object reference private and protected members are not accessable
            obj.a = 10;
            obj.d = 20;
            obj.e = 30;
        }
    }
}
