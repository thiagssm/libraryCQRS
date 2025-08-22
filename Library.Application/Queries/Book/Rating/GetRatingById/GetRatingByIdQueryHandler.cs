using Library.Application.DTOs.Book;
using Library.Core.Model;
using Library.Core.Repositories;
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
        private readonly IRatingRepository _ratingRepository;
        public GetRatingByIdQueryHandler(IRatingRepository repository)
        {
            _ratingRepository = repository;
        }

        public async Task<RatingViewModel> Handle(GetRatingByIdQuery request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.GetByIdAsync(request.ratingId);

            var ratingViewModel = new RatingViewModel(
                rating.Value,
                rating.Description,
                rating.IdUser,
                rating.IdBook,
                rating.User.Name
            );

            return ratingViewModel;
        }
    }
}
