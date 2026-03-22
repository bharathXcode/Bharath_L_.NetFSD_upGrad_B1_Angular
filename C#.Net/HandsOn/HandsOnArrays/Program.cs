namespace HandsOnArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array declaration
            int[] number = new int[5];
            //assign values to the array
            number[0] = 98;
            number[1] = 67;
            number[2] = 88;
            //number[3] = 87;
            //number[4] = 90;
            //number[10] = 67; //exception
            //access value from the array
            int k = number[2];
            Console.WriteLine(k);
            foreach (int i in number)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for(int i=0;i<10;i++) //exception at 6th iteration
            {
                Console.Write(number[i] + " ");
            }
        }
    }
}
