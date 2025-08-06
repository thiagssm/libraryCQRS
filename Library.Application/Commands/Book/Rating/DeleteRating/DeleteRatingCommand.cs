using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.Rating.DeleteRating
{
    public class DeleteRatingCommand : IRequest<Unit>
    {
        public DeleteRatingCommand(int bookId, int id)
        {
            Id = id;
            BookId = bookId;
        }

        public int Id { get; private set; }
        public int BookId { get; private set; }
    }
}
