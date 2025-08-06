using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly LibraryDbContext _dbContext;
        public DeleteBookCommandHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.SingleOrDefaultAsync(book => book.Id == request.Id);

            book.Desativar();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
