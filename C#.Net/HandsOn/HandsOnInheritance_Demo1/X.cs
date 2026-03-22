using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInheritance
{
    public class X
    {
        int age;
        public X(int age)
        {
            this.age = age;
        }
        public void Show()
        {
            Console.WriteLine("Age= " + age);
        }
    }
    public class Y:X
    {
        public Y():base(23)
        {

        }
        public Y(int age) : base(age)        {
        }
      
    }
}
