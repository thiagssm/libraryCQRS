using Library.Application.DTOs.Book;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.Rating.GetRatingsByBookId
{
    public class GetRatingsByBookIdQueryHandler : IRequestHandler<GetRatingsByBookIdQuery, List<RatingViewModel>>
    {
        private readonly LibraryDbContext _dbContext;
        public GetRatingsByBookIdQueryHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<RatingViewModel>> Handle(GetRatingsByBookIdQuery request, CancellationToken cancellationToken)
        {
            var ratings = await _dbContext.Ratings
                .Where(r => r.IdBook == request.BookId)
                .Include(r => r.User)
                .Select(r =>
                    new RatingViewModel(
                        r.Value,
                        r.Description,
                        r.IdUser,
                        r.IdBook,
                        r.User.Name
                    )
                ).ToListAsync();

            return ratings;
        }
    }
}
