using Library.Core.Model;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.Repositories;
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
        private readonly RatingRepository _ratingRepository;
        private readonly BookRepository _bookRepository;
        public CreateRatingCommandHandler(RatingRepository repository,BookRepository bookRepository)
        {
            _ratingRepository = repository;
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {

            var rating = new Library.Core.Model.Rating(
                request.Value,
                request.Description,
                request.IdUser,
                request.IdBook
            );

            await _ratingRepository.AddAsync(rating);

            var book = await _bookRepository.GetByIdAsync(request.IdBook);

            List<Library.Core.Model.Rating> ratings = await _ratingRepository.GetByBookIdAsync(book.Id);

            ratings.Add(rating);

            book.RecalculateAverageRating(ratings);

            await _ratingRepository.SaveChangesAsync();

            return rating.Id;
        }
    }
}
