using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnArrays
{
    internal class Demo4
    {
        static void Main()
        {
            //jagged array
            int[][] _jagged = new int[3][];
            //assign arrays to elements
            _jagged[0] = new int[5] { 1, 23, 4, 5, 59 };
            _jagged[1] = new int[3] { 34, 45, 56 };
            _jagged[2] = new int[4] { 1, 2, 2, 3 };
            Console.WriteLine(_jagged[0][2]); //4
            foreach(int k in _jagged[0])
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
            foreach(int k in _jagged[1])
            {
                Console.Write(k + " ");
            }
        }
    }
}
