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

namespace Library.Application.Queries.Book.Rating.GetRatingsByBookId
{
    public class GetRatingsByBookIdQueryHandler : IRequestHandler<GetRatingsByBookIdQuery, List<RatingViewModel>>
    {
        private readonly IRatingRepository _ratingRepository;
        public GetRatingsByBookIdQueryHandler(IRatingRepository repository)
        {
            _ratingRepository = repository;
        }
        public async Task<List<RatingViewModel>> Handle(GetRatingsByBookIdQuery request, CancellationToken cancellationToken)
        {
            var ratings = await _ratingRepository.GetByBookIdAsync(request.BookId);

            var ratingsViewModels = ratings
                .Select(r =>
                    new RatingViewModel(
                        r.Value,
                        r.Description,
                        r.IdUser,
                        r.IdBook,
                        r.User.Name
                    )
                ).ToList();

            return ratingsViewModels;
        }
    }
}
