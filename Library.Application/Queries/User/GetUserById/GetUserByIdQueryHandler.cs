using Azure.Core;
using Library.Application.DTOs.Book;
using Library.Application.DTOs.User;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.User.GetUserById
{
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly LibraryDbContext _dbContext;
        public GetUserByIdQueryHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null) return null;

            var userViewModel = new UserViewModel
            (
                user.Name,
                user.Email
            );

            return userViewModel;
        }
    }
}
