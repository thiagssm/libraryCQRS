using Library.Application.Commands.Book.CreateBook;
using Library.Application.Commands.Book.Rating.CreateRating;
using Library.Application.Commands.Book.UpdateBook;
using Library.Application.Commands.Book;
using Library.Application.Commands.Book.Rating;
using Library.Application.DTOs.Book;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Library.Application.Commands.Book.DeleteBook;
using Library.Application.Commands.Book.Rating.DeleteRating;
using Library.Application.Queries.Book.GetBookById;
using Library.Application.Queries.Book.GetAllBooks;
using Library.Application.Queries.Book.GetBookByTitle;
using Library.Application.Queries.Book.Rating.GetRatingById;
using Library.Application.Queries.Book.Rating.GetRatingsByBookId;

namespace Library.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController( IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBookByIdQuery(id);
            
            var book = await _mediator.Send(query);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("by-title")]
        public async Task<IActionResult> GetByTitle([FromQuery] string title)
        {
            var query = new GetBookByTitleQuery(title);
            var book = await _mediator.Send(query);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBooksQuery();
            var books = await _mediator.Send(query);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var bookId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = bookId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] UpdateBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{bookId}/Ratings")]
        public async Task<IActionResult> PostRating([FromBody] CreateRatingCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{bookId}/Ratings")]
        public async Task<IActionResult> GetRatingsByBookId(int bookId)
        {
            var query = new GetRatingsByBookIdQuery(bookId);
            var ratings = await _mediator.Send(query);

            if (ratings == null)
            {
                return NotFound();
            }

            return Ok(ratings);
        }

        [HttpGet("{bookId}/Ratings/{ratingId}")]
        public async Task<IActionResult> GetRatingById(int ratingId)
        {
            var query = new GetRatingByIdQuery(ratingId);
            var rating = await _mediator.Send(query);

            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        [HttpDelete("{bookId}/Ratings/{ratingId}")]
        public async Task<IActionResult> DeleteRating(int bookId, int ratingId)
        {
            var command = new DeleteRatingCommand(bookId, ratingId);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
