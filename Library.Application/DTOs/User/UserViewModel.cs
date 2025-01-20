using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.User
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        //public List<RatingModel> Ratings { get; set; }
    }
}
