using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnArrays
{
    internal class Demo3
    {
        static void Main()
        {
            //2-dimensional array
            int[,] _2d = new int[3, 2];
            Console.WriteLine("size: "+_2d.Length);
            Console.WriteLine("rank: " + _2d.Rank);
            //assign values
            _2d[0,0] = 1;
            _2d[0,1] = 2;

            _2d[1, 0] = 3;
            _2d[1, 1] = 4;

            _2d[2, 0] = 10;
            _2d[2, 1] = 20;
            //access value
            Console.WriteLine(_2d[1, 1]);
            //access all the values
            foreach(int k in _2d)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
            //display in matrix format
            for(int i=0;i<3;i++)
            {
                for(int j = 0; j <2;j++)
                {
                    Console.Write(_2d[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
