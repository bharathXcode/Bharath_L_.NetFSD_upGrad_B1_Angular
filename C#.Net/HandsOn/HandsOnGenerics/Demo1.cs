using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnGenerics
{
    class KeyValue<T,V>
    {
        public T Key { get; set; }
        public V Value { get; set; }
        public void Show()
        {
            Console.WriteLine($"Key:{Key} Value:{Value}");
        }
    }
    internal class Demo1
    {
        static void Main()
        {
            KeyValue<int, string> obj = new KeyValue<int, string>();
            obj.Key = 342083;
            obj.Value = "Tina";
            obj.Show();
        }
    }
}
