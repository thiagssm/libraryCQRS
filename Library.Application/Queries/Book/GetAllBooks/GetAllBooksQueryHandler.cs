using Library.Application.DTOs.Book;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly LibraryDbContext _dbContext;
        public GetAllBooksQueryHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            {
                var booksViewModel = await _dbContext.Books
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
                        b.Ratings
                        ))
                    .ToListAsync();

                return booksViewModel;
            }
        }
    }
}
