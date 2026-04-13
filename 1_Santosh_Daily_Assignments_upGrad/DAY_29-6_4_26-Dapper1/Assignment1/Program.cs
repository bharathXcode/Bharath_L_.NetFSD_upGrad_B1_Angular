using Assignment1.Data;
using Assignment1.Services;
using Assignment1.UI;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new DbContext();
            var repo = new BookRepository(context);
            var service = new BookServices(repo);
            var ui = new ConsoleUI(service);
            ui.Start();
        }
    }
}
