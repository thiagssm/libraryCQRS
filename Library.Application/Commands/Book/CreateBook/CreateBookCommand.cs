using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public int PublicationYear { get; set; }
        public int PageCount { get; set; }
        // Adicionar os bytes criptografados quando for utilizar a CoverImage
        public string CoverImage { get; set; }
    }
}
