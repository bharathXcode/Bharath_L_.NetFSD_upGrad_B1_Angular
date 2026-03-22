using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling
{
    internal class Demo9
    {
        static void Main()
        {
            try
            {
               
                int number = int.Parse("abc");
            }
            catch (Exception ex) when (ex is FormatException)
            {
                Console.WriteLine("Invalid number error");
            }
            catch (FormatException ex) when (ex.Message.Contains("input"))
            {
                Console.WriteLine("Invalid number format");
            }
        }
    }
}
