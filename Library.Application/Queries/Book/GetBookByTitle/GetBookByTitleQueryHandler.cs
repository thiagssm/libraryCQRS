using Library.Application.DTOs.Book;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.GetBookByTitle
{
    public class GetBookByTitleQueryHandler : IRequestHandler<GetBookByTitleQuery, List<BookViewModel>>
    {
        private readonly LibraryDbContext _dbContext;
        public GetBookByTitleQueryHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookViewModel>> Handle(GetBookByTitleQuery request, CancellationToken cancellationToken)
        {
            var books = await _dbContext.Books
                .Where(book => book.Title == request.Title)
                .ToListAsync();

            var booksViewModel = books
                .Select(b => new BookViewModel(
                b.Title,
                b.Description,
                b.Author,
                b.ISBN,
                b.Publisher,
                b.Category,
                b.PublicationYear,
                b.PageCount,
                b.CoverImage,
                b.AverageRating,
                b.Ratings)).ToList();

            return booksViewModel;
        }
    }
}