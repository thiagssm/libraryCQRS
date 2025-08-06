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

namespace Library.Application.Queries.Book.Rating.GetRatingById
{
    public class GetRatingByIdQueryHandler : IRequestHandler<GetRatingByIdQuery, RatingViewModel>
    {
        private readonly LibraryDbContext _dbContext;
        public GetRatingByIdQueryHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RatingViewModel> Handle(GetRatingByIdQuery request, CancellationToken cancellationToken)
        {
            var rating = await _dbContext.Ratings.Where(r => r.Id == request.ratingId)
                .Select(r =>
                    new RatingViewModel(
                        r.Value,
                        r.Description,
                        r.IdUser,
                        r.IdBook,
                        r.User.Name
                    )
                ).SingleOrDefaultAsync();

            return rating;
        }
    }
}
