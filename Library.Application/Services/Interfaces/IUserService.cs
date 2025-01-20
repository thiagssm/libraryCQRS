using Library.Application.DTOs.User;
using Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);

        List<UserViewModel> GetAll();

        int Create(CreateUserInputModel model);

        void Update(UpdateUserInputModel model);

        void Login(LoginModel model);

        void Delete(int id);
    }
}
