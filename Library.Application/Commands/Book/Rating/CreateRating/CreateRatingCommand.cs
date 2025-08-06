using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.Rating.CreateRating
{
    public class CreateRatingCommand : IRequest<int>
    {
        public int Value { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
    }
}
