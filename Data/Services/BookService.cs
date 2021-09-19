using my_book_api.Data.Models;
using my_book_api.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book_api.Data.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext context;

        public BookService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            context.Books.Add(_book);
            context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return context.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public Book UpdateBookById(int id,BookVM book)
        {
            var _book = context.Books.FirstOrDefault(b => b.Id == id);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int id)
        {
            var _book = context.Books.FirstOrDefault(b => b.Id == id);
            if(_book!=null)
            {
                context.Books.Remove(_book);
                context.SaveChanges();
            }
        }
    }
}
