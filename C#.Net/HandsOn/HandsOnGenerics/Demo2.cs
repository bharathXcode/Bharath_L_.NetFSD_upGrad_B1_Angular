using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnGenerics
{
    public interface ICalculator<T>
    {
        T Add(T a, T b);
    }
    class Calculate:ICalculator<int>
    {
        public int Add(int a,int b)
        {
            return a + b;
        }
    }
    internal class Demo2
    {
    }
}
