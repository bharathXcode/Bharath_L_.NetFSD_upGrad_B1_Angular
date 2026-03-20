using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public int Id;
    public string Title;
    public double Price;
    public string Category;
}

class Q1_BookList
{
    public static void Main()
    {
        List<Book> books = new List<Book>
        {
            new Book{Id=1, Title="Java", Price=1200, Category="Programming"},
            new Book{Id=2, Title="Python", Price=900, Category="Programming"},
            new Book{Id=3, Title="C#", Price=1500, Category="Programming"},
            new Book{Id=4, Title="Maths", Price=800, Category="Academic"},
            new Book{Id=5, Title="Physics", Price=1100, Category="Academic"},
            new Book{Id=6, Title="Chemistry", Price=950, Category="Academic"},
            new Book{Id=7, Title="History", Price=700, Category="General"},
            new Book{Id=8, Title="Geography", Price=600, Category="General"},
            new Book{Id=9, Title="English", Price=500, Category="General"},
            new Book{Id=10, Title="Biology", Price=1300, Category="Academic"}
        };

        Console.WriteLine("All Books:");
        books.ForEach(b => Console.WriteLine(b.Title + " - " + b.Price));

        Console.WriteLine("\nBooks > 1000:");
        foreach (var b in books.Where(x => x.Price > 1000))
            Console.WriteLine(b.Title);

        Console.WriteLine("\nAscending:");
        foreach (var b in books.OrderBy(x => x.Price))
            Console.WriteLine(b.Title);

        Console.WriteLine("\nDescending:");
        foreach (var b in books.OrderByDescending(x => x.Price))
            Console.WriteLine(b.Title);

        books.RemoveAll(x => x.Id == 10);

        Console.WriteLine("\nProgramming Books:");
        foreach (var b in books.Where(x => x.Category == "Programming"))
            Console.WriteLine(b.Title);
    }
}
