using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInheritance
{
    public class AA
    {
        public int age;
        public void Show()
        {
            Console.WriteLine("Show::A");
        }
    }
    public class BB:AA
    {
        //new keyword use to avoid the compilor warnings
        public new int age;
        public new void Show()
        {
            base.Show(); //invokes AA class show() method
            Console.WriteLine("Show::B");
        }
    }
    class Test_BB
    {
        static void Main()
        {
            BB obj=new BB();
            obj.Show(); //invoking BB class Show() method
            AA ob = new BB();
            ob.Show(); //Invoking AA class Show() method
        }

    }

}
