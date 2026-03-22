using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnFileOperations
{
    internal class Demo2
    {
        public static int Div(int a,int b)
        {
            try
            {
                int c = a / b;
                return c;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public static void WriteData()
        {
            try
            {
                throw new NotFiniteNumberException
                    ("Given file not exisit");
            }
            catch(IOException)
            {
                throw;
            }
        }
        static void Main()
        {
            try
            {
                // Div(12, 0);
                WriteData();
            }
            catch(Exception ex)
            {
                //Log error details
                ErrorLogger.WriteErrorToLogFile(ex);
            }
        }
    }
}
