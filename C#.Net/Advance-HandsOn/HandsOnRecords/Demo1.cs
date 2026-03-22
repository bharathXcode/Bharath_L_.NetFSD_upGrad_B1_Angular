using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnRecords
{
    //(Non-Positional)
    public record Book
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
    internal class Demo1
    {
        static void Main()
        {
            Book book = new Book() { Id = 3420, Name = "Dotnet" };
            //book.Id = 303; compilaton erro
        }
    }
}
