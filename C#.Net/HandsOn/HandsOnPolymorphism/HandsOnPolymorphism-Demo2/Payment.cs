namespace HandsOnPolymorphism_Demo2
{
    public  class Payment
    {
        public virtual void Pay(decimal amount)
        {
            Console.WriteLine("Payment is Processing..");
        }
    }

}
