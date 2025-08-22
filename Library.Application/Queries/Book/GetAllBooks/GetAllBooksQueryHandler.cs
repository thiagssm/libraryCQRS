using Library.Application.DTOs.Book;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.Repositories;
using Library.Core.Repositories;
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
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IBookRepository repository)
        {
            _bookRepository = repository;

        }

        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            {
                var books = await _bookRepository.GetAllAsync();
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
                        b.Ratings
                        ))
                    .ToList();

                return booksViewModel;
            }
        }
    }
}
