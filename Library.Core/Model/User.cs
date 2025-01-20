using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class User : BaseModel
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

            Ratings = new List<Rating>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public List<Rating> Ratings { get; private set; }

        public void Update(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
