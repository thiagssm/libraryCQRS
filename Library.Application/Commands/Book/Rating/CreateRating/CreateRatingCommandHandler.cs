using Library.Core.Model;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.Rating.CreateRating
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, int>
    {
        private readonly LibraryDbContext _dbContext;
        public CreateRatingCommandHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _dbContext.Users.AnyAsync(u => u.Id == request.IdUser);
            if (!userExists)
            {
                throw new Exception("O usuário informado não foi encontrado.");
            }

            var rating = new Library.Core.Model.Rating(
                request.Value,
                request.Description,
                request.IdUser,
                request.IdBook
            );

            _dbContext.Ratings.Add(rating);

            var book = await _dbContext.Books.SingleOrDefaultAsync(book => book.Id == request.IdBook);

            List<Library.Core.Model.Rating> ratings = _dbContext.Ratings.Where(r => r.IdBook == book.Id).ToList();

            ratings.Add(rating);

            book.RecalculateAverageRating(ratings);

            await _dbContext.SaveChangesAsync();

            return rating.Id;
        }
    }
}
