using BookShelf.Application.DTOs;
using BookShelf.Application.Interfaces;
using BookShelf.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookShelf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookRepository.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost("createBook")]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto book)
        {
            var createdBook = await _bookRepository.CreateAsync(book);
            return Ok(createdBook);
        }

        [HttpPost("updateBook")]
        public async Task<ActionResult<BookDto>> UpdateBook(UpdateBookDto book)
        {
            var updatedBook = await _bookRepository.UpdateAsync(book);
            return Ok(updatedBook);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var result = await _bookRepository.DeleteAsync(id);
            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
