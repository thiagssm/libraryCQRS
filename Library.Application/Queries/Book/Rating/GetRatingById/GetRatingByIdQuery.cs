using Library.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.Rating.GetRatingById
{
    public class GetRatingByIdQuery:IRequest<RatingViewModel>
    {
        public GetRatingByIdQuery(int ratingId)
        {
            this.ratingId = ratingId;
        }

        public int ratingId { get; private set; }
    }
}
