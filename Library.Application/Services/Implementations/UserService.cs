using Library.Application.DTOs.User;
using Library.Application.Services.Interfaces;
using Library.Core.Model;
using Library.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Implementations
{
    internal class UserService:IUserService
    {
        LibraryDbContext _dbContext;
        public UserService(LibraryDbContext libraryDbContext)
        {
            _dbContext = libraryDbContext;
        }

        public int Create(CreateUserInputModel model)
        {
            var user = new User(
                model.Name,
                model.Email,
                model.Password
                );

            _dbContext.Users.Add(user);

            return user.Id;
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            user.Desativar();
        }

        public List<UserViewModel> GetAll()
        {
            var usersViewModel = _dbContext.Users.Select(u => new UserViewModel
            (
                u.Name,
                u.Email
            )).ToList();

            return usersViewModel;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null) return null;

            var userViewModel = new UserViewModel
            (
                user.Name,
                user.Email
            );

            return userViewModel;
        }

        public void Login(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateUserInputModel model)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == model.Id);
            user.Update(model.Name, model.Email, model.Password);
        }
    }
}
