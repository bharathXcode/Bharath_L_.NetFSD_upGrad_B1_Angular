using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HandsOnFileOperations
{
    internal class ErrorLogger
    {
        public static void WriteErrorToLogFile(Exception ex)
        {
            string date = DateTime.Now.ToString(); //current Date And Time
            string error_message = ex.Message;
            string project = ex.Source; //returns project name
            string error = $"Date:{date} Project:{project} Message:{error_message}";
            using (StreamWriter sw = new StreamWriter("errlog.txt", true))
            {
                sw.WriteLine(error);
            }
        }
    }
}
