using Library.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.Rating.GetRatingsByBookId
{
    public class GetRatingsByBookIdQuery:IRequest<List<RatingViewModel>>
    {
        public GetRatingsByBookIdQuery(int bookId)
        {
            BookId = bookId;
        }

        public int BookId { get; private set; }
    }
}
