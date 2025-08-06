using Library.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.User.GetAllUsers
{
    public class GetAllUsersQuery:IRequest<List<UserViewModel>>
    {
    }
}
