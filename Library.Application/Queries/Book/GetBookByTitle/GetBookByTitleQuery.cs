using Library.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.GetBookByTitle
{
    public class GetBookByTitleQuery:IRequest<List<BookViewModel>>
    {
        public GetBookByTitleQuery(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
    }
}
