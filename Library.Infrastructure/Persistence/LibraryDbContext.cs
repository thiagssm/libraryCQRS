using Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence
{
    public class LibraryDbContext
    {
        public LibraryDbContext()
        {
            Users = new List<User>
            {
                new User("Thiago", "thiago@gmail.com", "1234"),
                new User("Thiago2", "thiago2@gmail.com", "1234")
            };

            Ratings = new List<Rating>
            {
                new Rating(5, "Muito bom!!", 1, 1),
                new Rating(1, "Muito ruim!!", 1, 1)
            };

            Books = new List<Book>
           {
               new Book(1,"O milagre da manhã", "manha incrivel", "adam", "31312", "saraiva", Commons.Enum.eBookCategory.Science.ToString(), 1990, 200, ""),
               new Book(2,"Mais esperto que o diabo", "diabo", "adam", "3131233", "saraiva", Commons.Enum.eBookCategory.Science.ToString(), 1990, 250, "")
           };
        }

        public List<User> Users { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Book> Books { get; set; }
    }
}
