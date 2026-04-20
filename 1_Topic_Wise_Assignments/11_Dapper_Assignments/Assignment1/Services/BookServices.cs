using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.Data;
using Assignment1.Models;

namespace Assignment1.Services
{
    public class BookServices
    {
        private readonly BookRepository _repo;
        public BookServices(BookRepository repo)
        {
            _repo = repo;
        }
        public void AddBook(Book book) => _repo.Add(book);
        public void UpdateBook(Book book) => _repo.Update(book);
        public void DeleteBook(int Id)=>_repo.Delete(Id);
        public Book GetBook(int Id)=>_repo.GetById(Id);
        public IEnumerable<Book> GetBooks() => _repo.GetAll();
        public IEnumerable<Book> GetByName(string name)=>_repo.GetByName(name);
        public IEnumerable<Book> GetByAuthor(string author)=>_repo.GetByAuthor(author);
        public IEnumerable<Book> GetByLanguage(string lang)=>_repo.GetByLanguage(lang);
        public IEnumerable<Book> GetByPublisher(string pub)=>_repo.GetByPublisher(pub);
    }
}
