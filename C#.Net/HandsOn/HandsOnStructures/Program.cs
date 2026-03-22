namespace HandsOnStructures
{
    struct Box
    {
        //variable
        //methods
        //constructors
        //propertie
        public int _length;
        public int _heigth;
        //public int area=0; //structure does not support instace variable intialization
        private static int area = 0;
        public Box()
        {
            _length = 20;
            _heigth = 21;
        }
        public Box(int l, int h)
        {
            _length = l;
            _heigth = h;
        }
        public void Area()
        {
            area = _length * _heigth;
            Console.WriteLine("Area of a Box: "+area);
        }
        //Property
        //public int Area
        //{
        //    get { return _length *_heigth; }
        //}
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //instantiate structure
            Box b;
            b._length = 20;
            b._heigth = 10;
            b.Area();
            Box b1 = new Box(12, 23); //constructor invoked
            b1.Area();
            Box b2; //constructor is not invoked
            b2._length = 12;
            b2._heigth = 20;
            b2.Area();
            Box b3 = new Box();
            b3.Area();
        }
    }
}
