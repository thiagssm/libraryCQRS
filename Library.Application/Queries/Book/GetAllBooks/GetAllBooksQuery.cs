﻿using Library.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.GetAllBooks
{
    public class GetAllBooksQuery:IRequest<List<BookViewModel>>
    {
    }
}
