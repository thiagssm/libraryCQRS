using Library.Application.DTOs.Book;
using Library.Core.Repositories;
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
        private readonly IBookRepository _bookRepository;
        public GetBookByTitleQueryHandler(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        public async Task<List<BookViewModel>> Handle(GetBookByTitleQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetByTitleAsync(request.Title);

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