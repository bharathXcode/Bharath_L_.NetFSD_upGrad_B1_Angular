using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnCsharpNewFeatures
{
    //primary constructors stucts
    public struct Point(int x, int y)
    {
        public int X => x;
        public int Y => y;
    }
    internal class Demo2
    {
    }
}
