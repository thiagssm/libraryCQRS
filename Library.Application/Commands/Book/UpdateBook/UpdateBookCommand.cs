using Library.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public bool Ativo { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public string Category { get; private set; }
        public int PublicationYear { get; private set; }
        public int PageCount { get; private set; }
        public decimal AverageRating { get; private set; }
    }
}
