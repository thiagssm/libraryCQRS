using Library.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.GetBookById
{
    public class GetBookByIdQuery:IRequest<BookViewModel>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
