using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly LibraryDbContext _dbContext;
        public UpdateBookCommandHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.SingleOrDefaultAsync(book => book.Id == request.Id);

            book.Update(request.Title, request.Description, request.Author, request.ISBN, request.Publisher, request.Category, request.PublicationYear, request.PageCount, request.Ativo);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
