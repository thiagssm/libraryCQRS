using Library.Core.Model;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.Rating.DeleteRating
{
    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, Unit>
    {
        private readonly LibraryDbContext _dbContext;
        public DeleteRatingCommandHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _dbContext.Ratings.SingleOrDefaultAsync(r => r.Id == request.Id && r.IdBook == request.BookId);

            rating.Desativar();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
