namespace HandsOnGenerics
{
    //generic class
    public class Sample<T>
    {
        public T value;
        public void Set(T v)
        {
            value = v;
        }
        public T Get()
        {
            return value;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Sample<int> sample = new Sample<int>();
            sample.Set(20);
            Console.WriteLine("Value: "+sample.Get());
            Sample<char> sample2 = new Sample<char>();
            sample2.Set('a');
            Console.WriteLine("Value: " + sample2.Get());
            Sample<string> sample3 = new Sample<string>();
            sample3.Set("Hello");
            Console.WriteLine("Value: " + sample3.Get());

        }
    }
}
