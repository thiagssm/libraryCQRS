using Library.Application.DTOs.User;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.User.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly LibraryDbContext _dbContext;
        public GetAllUsersQueryHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersViewModel = await _dbContext.Users.Select(u => new UserViewModel
            (
                u.Name,
                u.Email
            )).ToListAsync();

            return usersViewModel;
        }
    }
}
