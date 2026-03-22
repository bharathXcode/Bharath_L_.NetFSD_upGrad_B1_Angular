using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnSealedClasses_
{
    class X
    {
        public virtual void M() { }
        public virtual void G() { }
    }
    class Y:X
    {
        public sealed override void M() { }
        public override void G()
        {
           
        }
    }
    class Z:Y
    {
        //public override void M() //compilation error
        //{

        //}
        public override void G()
        {
            
        }
    }
    internal class Demo1
    {
    }
}
