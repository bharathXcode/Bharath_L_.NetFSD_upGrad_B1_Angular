using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.Models;
using Assignment1.Services;

namespace Assignment1.UI
{
    public class ConsoleUI
    {
        private readonly BookServices _service;
        public ConsoleUI(BookServices service)
        {
            _service = service;
        }
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n==== BOOK MENU ====");
                Console.WriteLine("1.Add  2.Edit  3.Delete  4.GetById");
                Console.WriteLine("5.GetByName  6.GetAll  7.ByAuthor");
                Console.WriteLine("8.ByLang  9.ByPublisher  0.Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var b = new Book
                        {
                            Title = Input("Title"),
                            Price = decimal.Parse(Input("Price")),
                            Author = Input("Author"),
                            Publisher = Input("Publisher"),
                            Language = Input("Language"),
                            PublishDate = DateTime.Parse(Input("Date"))
                        };
                        _service.AddBook(b);
                        break;

                    case 2:
                        int id = int.Parse(Input("Id"));
                        var book = _service.GetBook(id);
                        if (book != null)
                        {
                            book.Price = decimal.Parse(Input("New Price"));
                            book.Author = Input("New Author");
                            _service.UpdateBook(book);
                        }
                        break;

                    case 3:
                        _service.DeleteBook(int.Parse(Input("Id")));
                        break;

                    case 4:
                        Print(_service.GetBook(int.Parse(Input("Id"))));
                        break;

                    case 5:
                        PrintList(_service.GetByName(Input("Name")));
                        break;

                    case 6:
                        PrintList(_service.GetBooks());
                        break;

                    case 7:
                        PrintList(_service.GetByAuthor(Input("Author")));
                        break;

                    case 8:
                        PrintList(_service.GetByLanguage(Input("Lang")));
                        break;

                    case 9:
                        PrintList(_service.GetByPublisher(Input("Publisher")));
                        break;

                    case 0:
                        return;
                }
            }
        }
         string Input(string msg)
        {
            Console.Write($"{msg}: ");
            return Console.ReadLine();
        }

        void Print(Book b)
        {
            if (b != null)
                Console.WriteLine($"{b.BookId} {b.Title} {b.Author} {b.Price}");
        }

        void PrintList(IEnumerable<Book> list)
        {
            foreach (var b in list)
                Console.WriteLine($"{b.BookId} {b.Title} {b.Author} {b.Price}");
        }
    }
}
