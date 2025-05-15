using Library.Application.DTOs.Book;
using Library.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Library.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("by-title")]
        public IActionResult GetByTitle([FromQuery] string title)
        {
            var book = _bookService.GetByTitle(title);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAll();

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateBookInputModel model)
        {
            var bookId = _bookService.Create(model);

            return CreatedAtAction(nameof(GetById), new { id = bookId }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] UpdateBookInputModel model)
        {
            _bookService.Update(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/Ratings")]
        public IActionResult PostRating([FromBody] CreateRatingInputModel model)
        {
            _bookService.CreateRating(model);

            return NoContent();
        }

        [HttpGet("{id}/Ratings")]
        public IActionResult GetAllRatings(int bookId)
        {
            var books = _bookService.GetRatings(bookId);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("{bookId}/Ratings/{ratingId}")]
        public IActionResult GetRatingById(int bookId, int ratingId)
        {
            var books = _bookService.GetRatingById(bookId, ratingId);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpDelete("{bookId}/Ratings/{ratingId}")]
        public IActionResult DeleteRating(int bookId, int ratingId)
        {
            _bookService.DeleteRating(bookId, ratingId);

            return NoContent();
        }
    }
}
