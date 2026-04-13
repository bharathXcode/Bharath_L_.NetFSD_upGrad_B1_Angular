using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Assignment1.Models;
using Dapper;

namespace Assignment1.Data
{
    public class BookRepository
    {
        private readonly DbContext _context;
        public BookRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            using var db = _context.CreateConnection();
            string sql = @"INSERT INTO Books(Title,Price,Author,Publisher,Language,PublishDate) values(@Title,@Price,@Author,@Publisher,@Language,@PublishDate)";
            db.Execute(sql, book);
        }

        public void Delete(int Id)
        {
            using var db= _context.CreateConnection();
            db.Execute("DELETE FROM Books WHERE BookId=@Id",new {Id});
        }

        public IEnumerable<Book> GetAll()
        {
            using var db=_context.CreateConnection();
            return db.Query<Book>("SELECT * FROM Books");
        }

        public IEnumerable<Book> GetByAuthor(string Author)
        {
            using var db = _context.CreateConnection();
            return db.Query<Book>("SELECT * FROM Books WHERE Author=@Author", new { Author });
        }

        public Book GetById(int Id)
        {
            using var db = _context.CreateConnection();
            return db.QueryFirstOrDefault<Book>("SELECT * FROM Books WHERE BookId=@Id", new { Id });
        }

        public IEnumerable<Book> GetByLanguage(string Language)
        {
            using var db=_context.CreateConnection();
            return db.Query<Book>("SELECT * FROM Books WHERE Language=@Language", new { Language });
        }

        public IEnumerable<Book> GetByName(string Name)
        {
            using var db = _context.CreateConnection();
            return db.Query<Book>("SELECT * FROM Books WHERE Title LIKE @Name",new { name = "%" + Name + "%" });
        }

        public IEnumerable<Book> GetByPublisher(string Publisher)
        {
            using var db = _context.CreateConnection();
            return db.Query<Book>("SELECT * FROM Books WHERE Publisher=@Publisher", new { Publisher });
        }

        public void Update(Book book)
        {
            using var db = _context.CreateConnection();
            string sql = @"UPDATE Books SET Price=@Price, Author=@Author,Publisher=@Publisher, Language=@Language, PublishDate=@PublishDate WHERE BookId=@BookId";
            db.Execute(sql, book);
        }
    }
}
