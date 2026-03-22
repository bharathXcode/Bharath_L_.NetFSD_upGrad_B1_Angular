namespace HandsOnSealedClasses_
{
    sealed class A
    {
        public void M()
        {
           //having sensitive data
        }
    }
    class B
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            A obj = new A();//sealed classes are instantiated
            obj.M();
        }
    }
}
