using Azure.Core;
using Library.Application.DTOs.Book;
using Library.Core.Model;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookViewModel>
    {
        private readonly LibraryDbContext _dbContext;
        public GetBookByIdQueryHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books
                .Include(b => b.Ratings)
                .SingleOrDefaultAsync(book => book.Id == request.Id);

            if (book == null) return null;

            var bookView = new BookViewModel(
                book.Title,
                book.Description,
                book.Author,
                book.ISBN,
                book.Publisher,
                book.Category,
                book.PublicationYear,
                book.PageCount,
                book.CoverImage,
                book.AverageRating,
                book.Ratings);

            return bookView;
        }
    }
}
