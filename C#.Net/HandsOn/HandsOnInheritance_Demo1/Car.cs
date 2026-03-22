namespace HandsOnInheritance
{
    // Single / Multilevel Inheritance
    public class Car : Vehicle
    {
        public string Model;
        public Car():base("Honda")
        {

        }
        public Car(string brand, string model) : base(brand)
        {
            Model = model;
            Console.WriteLine($"Car constructor called. Model: {Model}");
        }

        //// Method hiding
        public  new void Start() // hides Vehicle.Start()
        {
            Console.WriteLine("Car is starting with ignition key...");
        }
        public void Details()
        {
            //Start();//invoke child class Start
            base.Start(); //invoke parent class Start
            Console.WriteLine($"Brand:{Brand} Model:{Model}");
        }
    }
    public class Test_Car
    {
        static void Main()
        {
            Car car = new Car("Hundai", "i10");
            car.Details();
            //method hiding applied
            //here Vehicle class Start() is hide
            car.Start();//invokes Start() of Car class
        }
    }

}
