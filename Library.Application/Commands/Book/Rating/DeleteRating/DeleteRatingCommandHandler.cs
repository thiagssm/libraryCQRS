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

namespace Library.Application.Commands.Book.Rating.DeleteRating
{
    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, Unit>
    {
        private readonly IRatingRepository _ratingRepository;
        public DeleteRatingCommandHandler(IRatingRepository repository)
        {
            _ratingRepository = repository;
        }

        public async Task<Unit> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.GetByIdAsync(request.Id);

            rating.Desativar();
            await _ratingRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
