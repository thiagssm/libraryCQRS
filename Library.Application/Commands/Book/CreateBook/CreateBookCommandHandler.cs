using Library.Core.Model;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly LibraryDbContext _dbContext;
        public CreateBookCommandHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Library.Core.Model.Book(
                request.Title,
                request.Description,
                request.Author,
                request.ISBN,
                request.Publisher,
                request.Category,
                request.PublicationYear,
                request.PageCount,
                request.CoverImage
            );

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book.Id;
        }
    }
}
