using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book_api.Data.Models.ViewModels;
using my_book_api.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService bookService;

        public BooksController(BookService bookService)
        {
            this.bookService = bookService;
        }
        
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            bookService.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = bookService.GetAllBooks();
            return Ok(allBooks);
        }
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody]BookVM book)
        {
            var updatedBook = bookService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            bookService.DeleteBookById(id);
            return Ok();
        }
    }
}
