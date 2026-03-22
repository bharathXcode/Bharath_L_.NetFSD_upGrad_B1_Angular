using ECommBL;
namespace ECommClient
{
    internal class Program
    {
        private readonly OrderRepo _repo;
        public Program()
        {
            _repo = new OrderRepo();
        }
        public static void Div(int a,int b)
        {
            try
            {
                int result = a / b;
                Console.WriteLine(result);
            }
            catch(DivideByZeroException ex)
            {
                throw;
            }
        }
        static void Main(string[] args)
        {
            //try
            //{
            //   OrderRepo _repo = new OrderRepo();
            //    string result=_repo.MakeOrdre("03323", -100);
            //    Console.WriteLine(result);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            try
            {
                Div(12, 0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
