using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_Hashset
{
    /*
     HashSet<T>

 What it is: A collection of unique items (no duplicates).

 When to use: When you need fast membership tests and uniqueness.
     */

    class Program
    {
        static void Main()
        {
            HashSet<string> countries = new HashSet<string>();
            countries.Add("India");
            countries.Add("USA");
            countries.Add("India"); // Duplicate ignored
            foreach (var c in countries)
            {
                Console.WriteLine(c);
            }
            HashSet<int> set1 = new HashSet<int>() { 12, 23, 34, 45 };
            HashSet<int> set2 = new HashSet<int>() { 13, 14, 15, 16, 12,45 };
            //set operations
            //set1.UnionWith(set2);
            //set1.IntersectWith(set2);
            set1.ExceptWith(set2);
           
            foreach(var k in set1)
            {
                Console.WriteLine(k);
            }

        }
    }

}
